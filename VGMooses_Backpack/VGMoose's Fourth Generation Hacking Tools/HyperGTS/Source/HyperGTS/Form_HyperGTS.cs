using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Threading;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.IO;


namespace HyperGTS
{
    public partial class Form_HyperGTS : Form
    {
        public Form_HyperGTS()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists(Application.StartupPath + "\\PKMs\\"))
                Directory.CreateDirectory(Application.StartupPath + "\\PKMs\\");
            IPHostEntry IPHost = Dns.GetHostEntry(Dns.GetHostName());
            TB_DNS_IP.Text = IPHost.AddressList[0].ToString();
            if (!IsValidIPAddress(TB_DNS_IP.Text))
            {
                TB_DNS_IP.Text = IPHost.AddressList[1].ToString();
                if (!IsValidIPAddress(TB_DNS_IP.Text))
                    TB_DNS_IP.Text = "000.000.000.000";
            }
            BT_DNS.Focus();
        }

        private bool IsValidIPAddress(string GetIPAddr)
        {
            try
            {
                IPAddress.Parse(GetIPAddr);
                if (GetIPAddr.Split('.').Length == 4)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void BT_DNS_Click(object sender, EventArgs e)
        {
            BT_DNS.Enabled = false;
            if (!IsValidIPAddress(TB_DNS_IP.Text))
            {
                MessageBox.Show("The IP adress you entered seems to be invalid. Please check it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!BGW_DNS.IsBusy)
            {

                TB_DNS_IP.Enabled = false;
                BT_DNS.Text = "STOP DNS";
                LB_DNS_Log.Items.Add(DateTime.Now.ToLongTimeString() + ": Sending command: Start DNS");
                LB_DNS_Log.SelectedIndex = LB_DNS_Log.Items.Count - 1;
                BGW_DNS.RunWorkerAsync(TB_DNS_IP.Text);
                LA_DNS_Status.Text = "DNS running";
                LA_DNS_Status.BackColor = Color.Green;
                BT_DNS.Enabled = true;
            }
            else
            {
                BGW_DNS.ReportProgress(1, "Sending command: Stop DNS");
                BGW_DNS.CancelAsync();

                //if (dnsserv != null)
                //    dnsserv.Shutdown(SocketShutdown.Both);
                //while (BGW_DNS.IsBusy)
                //{
                //    Thread.Sleep(1000);
                //}

                //BT_DNS.Enabled = true;
            }
        }

        private void BGW_DNS_DoWork(object sender, DoWorkEventArgs e)
        {
            string fake_ip = e.Argument.ToString();
            if (!IsValidIPAddress(fake_ip))
                return;
            BGW_DNS.ReportProgress(1, "DNS started...");
            Socket s;
            Socket dnsserv = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            dnsserv.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, 1);
            dnsserv.Bind(new IPEndPoint(IPAddress.Any, 53));

            byte[] fake_ip_byte = new byte[4];
            for (int i = 0; i <= 3; i++)
            {
                fake_ip_byte[i] = byte.Parse(fake_ip.Split('.')[i]);
            }

            byte[] r;
            byte[] rr = new byte[512];
            int lngSnd = 0;
            int lngRcv = 0;
            string str_r = null;
            string str_rr = null;
            string host = null;
            EndPoint rem_ep = new IPEndPoint(IPAddress.Any, 0);

            while (!BGW_DNS.CancellationPending)
            {
                try
                {
                    r = new byte[511];
                    dnsserv.ReceiveTimeout = 5000;
                    lngRcv = dnsserv.ReceiveFrom(r, SocketFlags.None, ref rem_ep);
                    //BGW_DNS.ReportProgress(1, "Connected to: " + rem_ep.ToString());
                    //r = new byte[lngRcv];
                    Array.Resize(ref r, lngRcv + 1);

                    str_r = Encoding.ASCII.GetString(r, 0, lngRcv);

                    host = str_r.Substring(12, str_r.IndexOf('\0', 12) - 12);

                    string requestedHost = "";
                    int n = 0;

                    while (n < host.Length)
                    {
                        requestedHost += host.Substring(n + 1, r[n + 12]) + ".";
                        n += r[n + 12] + 1;
                    }
                    requestedHost = requestedHost.Substring(0, requestedHost.Length - 1);

                    rr = new byte[511];
                    s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                    s.Connect("208.67.222.222", 53);
                    s.Send(r, lngRcv, SocketFlags.None);
                    lngSnd = s.Receive(rr, SocketFlags.None);
                    //rr = new byte[lngSnd];

                    Array.Resize(ref rr, lngSnd + 1);
                    if (requestedHost == "gamestats2.gs.nintendowifi.net")
                    {

                        Array.Copy(fake_ip_byte, 0, rr, 0x3c, 4);
                        BGW_DNS.ReportProgress(1, "Request (fake): " + requestedHost);

                    }
                    else
                        BGW_DNS.ReportProgress(1, "Request: " + requestedHost);


                    str_rr = Encoding.ASCII.GetString(rr, 0, lngSnd);

                    dnsserv.SendTo(rr, rr.Length, SocketFlags.None, rem_ep);
                }
                catch (SocketException ex)
                {//ErrorCode 10060
                    if (ex.ErrorCode != 10060)
                        BGW_DNS.ReportProgress(1, "Error (" + ex.Message + ")");
                }
                catch (Exception ex)
                {
                    BGW_DNS.ReportProgress(1, "Error (" + ex.Message + ")");
                }
            }
        }

        private void BGW_DNS_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            LB_DNS_Log.Items.Add(DateTime.Now.ToLongTimeString() + ": " + e.UserState.ToString());
            LB_DNS_Log.SelectedIndex = LB_DNS_Log.Items.Count - 1;
        }

        private void BGW_DNS_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            BGW_completed();
        }

        private void BGW_completed()
        {
            LB_DNS_Log.Items.Add(DateTime.Now.ToLongTimeString() + ": DNS stopped.");
            LB_DNS_Log.SelectedIndex = LB_DNS_Log.Items.Count - 1;
            LA_DNS_Status.Text = "DNS stopped";
            LA_DNS_Status.BackColor = Color.Red;
            BT_DNS.Text = "START DNS";
            TB_DNS_IP.Enabled = true;
            BT_DNS.Enabled = true;
        }

        private void LL_DNS_ClearLog_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LB_DNS_Log.Items.Clear();
            LB_DNS_Log.Items.Add(DateTime.Now.ToLongTimeString() + ": Log cleared.");
            LB_DNS_Log.SelectedIndex = LB_DNS_Log.Items.Count - 1;
        }

        private void BT_GTS_SendPKMN_Click(object sender, EventArgs e)
        {
            if (RB_GTS_SendOne.Checked)
            {
                if (File.Exists(TB_GTS_SendPKMN.Text))
                {
                    OFD_SendPKMN.InitialDirectory = "";
                    OFD_SendPKMN.FileName = TB_GTS_SendPKMN.Text;
                }
                else
                    OFD_SendPKMN.InitialDirectory = Application.StartupPath + "\\PKMs\\";

                if (OFD_SendPKMN.ShowDialog() == DialogResult.OK)
                {
                    TB_GTS_SendPKMN.Text = OFD_SendPKMN.FileName;
                }
                else
                {
                    TB_GTS_SendPKMN.Text = "";
                }
            }
            else
            {
                if (Directory.Exists(TB_GTS_SendPKMN.Text))
                    FBD_GTS_SendFolder.SelectedPath = TB_GTS_SendPKMN.Text;
                else
                    FBD_GTS_SendFolder.SelectedPath = Application.StartupPath + "\\PKMs\\";

                if (FBD_GTS_SendFolder.ShowDialog() == DialogResult.OK)
                {
                    TB_GTS_SendPKMN.Text = FBD_GTS_SendFolder.SelectedPath;
                }
                else
                {
                    if (Directory.Exists(Application.StartupPath + "\\PKMs\\"))
                        TB_GTS_SendPKMN.Text = Application.StartupPath + "\\PKMs\\";
                    else
                        TB_GTS_SendPKMN.Text = "";
                }
            }
        }

        private void BGW_GTS_DoWork(object sender, DoWorkEventArgs e)
        {
            BGW_GTS.ReportProgress(1, "GTS started...");
            Socket serv = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serv.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, 1);
            try
            {
                serv.Bind(new IPEndPoint(IPAddress.Any, 80));
            }
            catch (System.Net.Sockets.SocketException)
            {
                BGW_GTS.ReportProgress(1, "Server could not be started (Port 80 already used)");
                return;
            }
            
            serv.Listen(50);
            List<Socket> clients = new List<Socket>();

            SocketAsyncEventArgs saea = new SocketAsyncEventArgs();
            bool readyToContinueAccept = true;
            EventHandler<SocketAsyncEventArgs> clientAccepted = (sendr, eventargs) => // True Async request handling.
            {
                readyToContinueAccept = true; // AcceptAsync finished.
                if (eventargs.SocketError != SocketError.Success)
                    return; // did the AcceptAsync succeed? if not, quit.
                Socket client = eventargs.AcceptSocket; // get the new Socket (duh)

                ThreadPool.QueueUserWorkItem(si =>
                {
                    try
                    {
                        clients.Add(client);
                        asyncReq(client);

                    }
                    catch
                    {

                    }
                    finally
                    {
                        if (clients.Contains(client))
                            clients.Remove(client);
                        client.Close();
                    }
                });

            };
            saea.Completed += clientAccepted;
            Action continueAccept = () =>
            {
                saea.AcceptSocket = null;
                if (!serv.AcceptAsync(saea))
                {   // AcceptAsync completed synchronously, call ClientAccepted
                    clientAccepted(null, saea);
                }
            };
            while (true)
            {
                if (!BGW_GTS.CancellationPending)
                {

                    if (readyToContinueAccept) // has the previous AcceptAsync finished?
                    {
                        // if yes, launch another
                        readyToContinueAccept = false;
                        continueAccept();
                    } // if not, wait 30 ms and check again

                }
                else
                {
                    // cancellation pending
                    break; // let's quit
                }

                Thread.Sleep(30);
            }
            foreach (Socket client in clients)
            {
                if (client.Connected) client.Close();
            }
            serv.Close(); // this will call clientAccepted with saea.SocketError != SocketError.Success. It will do nothing.


            /*while (!BGW_GTS.CancellationPending)
            {
                try
                {
                    asyncReq(serv.Accept());
                }
                catch (Exception)
                {

                }
            }*/
        }

        public struct ReqStruct
        {
            public Socket sock;
            public Request req;
        }
        string currentDataFileName = "";

        private void asyncReq(Socket sk)
        {
            string ansStr = null;
            byte[] ans = { };
            ReqStruct reqst = default(ReqStruct);
            byte[] data = new byte[512];

            try
            {
                reqst = GetReq(ref sk);
            }
            catch (Exception ex)
            {
                BGW_GTS.ReportProgress(1, "Got wrong request, probably not from a DS. Error was : " + ex.Message);
                return;
            }

            Socket sock = reqst.sock;
            Request req = reqst.req;
            
            string pid = req.getvars["pid"];
            //BGW_GTS.ReportProgress(1, "Client " + sock.RemoteEndPoint.ToString());
            //BGW_GTS.ReportProgress(1, "Requesting : " + req.RequestedPage());

            
            byte[] bin = null;
            if (!CB_GTS_SendPKMN.Checked)
                currentDataFileName = "";
            else
            {
                if (CB_GTS_SendPKMN.Checked && RB_GTS_SendOne.Checked && currentDataFileName == "")
                    currentDataFileName = TB_GTS_SendPKMN.Text;
                else
                    if (CB_GTS_SendPKMN.Checked && RB_GTS_SendFolder.Checked)
                    {
                        do
                        {
                            if (PKMfromFolder.Count > 0)
                            {
                                currentDataFileName = PKMfromFolder[0];
                                if (!File.Exists(currentDataFileName))
                                {
                                    PKMfromFolder.RemoveAt(0);
                                    BGW_GTS.ReportProgress(1, "The file doesn't exist any more: " + currentDataFileName);

                                }
                                //FileInfo FI = new FileInfo(currentDataFileName);
                            }
                            else
                            {
                                currentDataFileName = "";
                                BGW_GTS.ReportProgress(3);
                            }
                        } while (!File.Exists(currentDataFileName) && PKMfromFolder.Count > 0);
                    }
            }
            bin = GetBin(currentDataFileName);

            if (req.getvars.Count == 1)
            {
                ansStr = RandStr(32);
            }
            else
            {
                byte[] encrypted_data = System.Convert.FromBase64String(req.getvars["data"].Replace("-", "+").Replace("_", "/"));
                data = Decrypt_data(encrypted_data);
                data = data.ToList().GetRange(4, data.Length - 4).ToArray();

                switch (req.action)
                {
                    case "info":
                        BGW_GTS.ReportProgress(1, "Someone has entered the GTS...");
                        ans = new byte[] { 1, 0 };

                        break;
                    case "setProfile":
                        ans = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 };

                        break;
                    case "result":
                        if (File.Exists(currentDataFileName))
                        {
                            //ans = File.ReadAllBytes(currentDataFileName);
                            ans = bin;
                            //ans = new byte[] { 4, 0 }; // * A Pokémon is present in the GTS.
                        }
                        else
                        {
                            //ans = new byte[] { 4, 0 }; // * A Pokémon is present in the GTS.

                            ans = new byte[] { 5, 0 }; // * There is no Pokémon stored.
                        }
                        break;
                    case "get":
                        if (File.Exists(currentDataFileName))
                        {
                            ans = File.ReadAllBytes(currentDataFileName);
                        }
                        break;
                    case "return":
                    case "delete":
                        if (File.Exists(currentDataFileName))
                        {
                            string pkmSpecie = Pokemon.dPKMSpecies[BitConverter.ToUInt16(bin, 236)];
                            BGW_GTS.ReportProgress(1, " * Sending " + pkmSpecie + " back to the game...");
                            //File.Delete(currentDataFileName);
                            if (CB_GTS_SendPKMN.Checked && RB_GTS_SendFolder.Checked && PKMfromFolder.Contains(currentDataFileName))
                            {
                                
                                PKMfromFolder.Remove(currentDataFileName);
                                do
                                {
                                    if (PKMfromFolder.Count > 0)
                                    {
                                        currentDataFileName = PKMfromFolder[0];
                                        FileInfo FI = new FileInfo(currentDataFileName);
                                        int actCount = (CountPKMfromFolder - PKMfromFolder.Count) + 1;
                                        BGW_GTS.ReportProgress(1, "Next Pkm (" + actCount + " of " + CountPKMfromFolder + "): " + FI.Name);
                                        if (!File.Exists(currentDataFileName))
                                        {
                                            BGW_GTS.ReportProgress(1, "The file doesn't exist any more: " + currentDataFileName);
                                            PKMfromFolder.RemoveAt(0);
                                        }
                                    }
                                    else
                                    {
                                        currentDataFileName = "";
                                        BGW_GTS.ReportProgress(1, "All pokemon from the folder have been sent.");
                                        BGW_GTS.ReportProgress(3);

                                    }
                                } while (!File.Exists(currentDataFileName) && PKMfromFolder.Count > 0);

                            }
                        }

                        ans = new byte[] { 1, 0 };

                        break;
                    case "post":
                
                        try
                        {
                            byte[] binData = data.ToList().GetRange(0, 236).ToArray();
                            byte[] postData = data.ToList().GetRange(236, data.Length - 236).ToArray();

                            byte[] pkmData = Pokemon.DecryptPokemon(binData);
                            string pkmSpecie = Pokemon.dPKMSpecies[BitConverter.ToUInt16(postData, 0)];
                            byte pkmLevel = postData[3];
                            string pkmGenderName = null;
                            switch (postData[2])
                            {
                                case 1:
                                    pkmGenderName = "male";

                                    break;
                                case 2:
                                    pkmGenderName = "female";

                                    break;
                                default:
                                    pkmGenderName = "genderless";
                                    break;
                            }

                            string filename = Application.StartupPath + "\\PKMs\\" + DateTime.Now.Ticks + "_" + pkmSpecie + "_" + pid + ".pkm";
                            File.WriteAllBytes(filename, pkmData);
                            //File.WriteAllBytes("Current\current_" & pid & ".pkm", pkmData)
                            //File.WriteAllBytes(currentDataFileName, data);

                            BGW_GTS.ReportProgress(1, " * A " + pkmSpecie + " (lvl " + pkmLevel + ", " + pkmGenderName + ") was deposited and converted to .pkm.");
                            BGW_GTS.ReportProgress(1, " * Filename : " + filename);
                            if (CB_GTS_SendAfterReceive.Checked)
                            {
                                BGW_GTS.ReportProgress(2, filename);
                                //TB_GTS_SendPKMN.Text = filename;
                                currentDataFileName = filename;

                            }
                            currentDataFileName = filename;
                            bin = GetBin(currentDataFileName);
                            if (!CB_GTS_Reject.Checked)
                                ans = new byte[] { 1, 0 };
                            else
                                ans = new byte[] { 0xc, 0 };
                        }
                        catch
                        {
                            BGW_GTS.ReportProgress(1, "Error, sending '0xc'.");
                            ans = new byte[] { 0xc, 0 };
                        }


                        break;
                    case "post_finish":
                        ans = new byte[] { 1, 0 };
                        break;
                    case "search":
                        Pokemon.InitializeDictionaries();
                        byte[] postdata = data.ToList().GetRange(0,2).ToArray();
                        UInt16 pkmnnr = BitConverter.ToUInt16(postdata, 0);
                        string pkmnname = Pokemon.dPKMSpecies[pkmnnr];
                        BGW_GTS.ReportProgress(1, "Searched for: #" + pkmnnr + " "+ pkmnname);
                        break;
                }
                Encoding E = Encoding.GetEncoding("iso-8859-1");
                ansStr = E.GetString(ans);
            }

            SendResp(ref sock, ansStr);
        }

        private byte[] GetBin(string currentDataFileName)
        {
            byte[] bin = null;
            if (File.Exists(currentDataFileName))
            {
                byte[] pkm = null;


                //currentDataFileName = TB_GTS_SendPKMN.Text;
                //pkm = File2PKMBytes(currentDataFileName);
                pkm = File.ReadAllBytes(currentDataFileName);
                bin = Pokemon.EncryptPokemon((byte[])(pkm.Clone()));

                if (pkm.Length < 236)
                {
                    Array.Resize(ref pkm, 236);
                }
                else if (pkm.Length > 236)
                {
                    BGW_GTS.ReportProgress(1, "Error : incorrect file size !");

                    return null;
                }

                byte[] binEnd = new byte[56];
                Array.Copy(pkm, 8, binEnd, 0, 2);
                //ID
                binEnd[2] = (byte)((pkm[64] & 4) > 0 ? 3 : (pkm[64] & 2) + 1);
                //Gender
                binEnd[3] = pkm[140];
                //Level
                Array.Copy(new byte[] { 0x1, 0x0, 0x3, 0x0, 0x0, 0x0, 0x0, 0x0 }, 0, binEnd, 4, 8);
                //Requesting Bulba, either, any
                Array.Copy(pkm, 0x68, binEnd, 32, 16);
                //OT name
                Array.Copy(pkm, 0xc, binEnd, 48, 2);
                //OT ID
                Array.Resize(ref bin, 292);
                Array.Copy(binEnd, 0, bin, 236, 56);
            }
            return bin;
        }

        private static byte[] File2PKMBytes(string filename)
        {
            byte[] bin;
            byte[] pkm = null;

            switch (Path.GetExtension(filename).ToLower())
            {
                case ".pkm":
                    pkm = File.ReadAllBytes(filename);
                    bin = Pokemon.EncryptPokemon((byte[])(pkm.Clone()));

                    break;
                case ".bin":
                    bin = File.ReadAllBytes(filename);
                    pkm = Pokemon.DecryptPokemon((byte[])(bin.Clone()));
                    break;
            }

            Array.Resize(ref pkm, 236);

            byte[] binEnd = new byte[56];
            Array.Copy(pkm, 8, binEnd, 0, 2);
            //ID
            binEnd[2] = (pkm[64] & 4) > 0 ? (byte)(3) : (byte)((pkm[64] & 2) + 1);
            //Gender
            binEnd[3] = pkm[140];
            //Level
            Array.Copy(new byte[] { 0x1, 0x0, 0x3, 0x0, 0x0, 0x0, 0x0, 0x0 }, 0, binEnd, 4, 8);
            //Requesting Bulba, either, any
            Array.Copy(pkm, 0x68, binEnd, 32, 16);
            //OT name
            Array.Copy(pkm, 0xc, binEnd, 48, 2);
            //OT ID
            bin = new byte[292];
            Array.Resize(ref bin, 292);
            Array.Copy(binEnd, 0, bin, 236, 56);

            return bin;
        }

        private static ReqStruct GetReq(ref Socket sock)
        {
            //Dim sock As Socket = serv.Accept()
            byte[] a = new byte[sock.ReceiveBufferSize];

            int cnt = sock.Receive(a, sock.ReceiveBufferSize, SocketFlags.None);
            Array.Resize(ref a, cnt);

            string data = Encoding.GetEncoding("iso-8859-1").GetString(a);

            ReqStruct ret = new ReqStruct();
            ret.req = new Request(data);
            ret.sock = sock;

            return ret;
        }

        private static int SendResp(ref Socket sock, object data)
        {
            Response resp = data is Response ? (Response)(data) : new Response(data.ToString());

            return sock.Send(Encoding.GetEncoding("iso-8859-1").GetBytes(resp.ToString()));
        }

        private static Response RespFromServ(Request req)
        {
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            s.Connect("207.38.11.146", 80);
            s.Send(Encoding.GetEncoding("iso-8859-1").GetBytes(req.ToString()));

            byte[] a = new byte[8192];

            int cnt = s.Receive(a, 8192, SocketFlags.None);
            Array.Resize(ref a, cnt);

            string data = Encoding.GetEncoding("iso-8859-1").GetString(a);

            return new Response(data);
        }

        private static string RandStr(int len)
        {
            string functionReturnValue = null;
            string pop = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            functionReturnValue = "";
            Random rnd = new Random();

            for (int i = 1; i <= len; i++)
            {
                functionReturnValue += pop[rnd.Next(0, pop.Length)];
            }
            return functionReturnValue;
        }

        //Private Sub serverResp()
        //Dim req As ReqStruct = GetReq()
        //Dim resp As Response = RespFromServ(req.req)
        //SendResp(req.sock, resp)
        //End Sub

        private static byte[] Decrypt_data(byte[] data)
        {
            List<byte> obf_key_blob = data.ToList().GetRange(0, 4);

            if (BitConverter.IsLittleEndian)
            {
                obf_key_blob.Reverse();
            }

            byte[] message = data.ToList().GetRange(4, data.Length - 4).ToArray();
            UInt32 obf_key = BitConverter.ToUInt32(obf_key_blob.ToArray(), 0);

            UInt32 key = obf_key ^ 0x4a3b2c1d;

            return Stream_decipher(message, new GTS_PRNG(key)).ToArray();
        }

        private static List<byte> Stream_decipher(byte[] data, GTS_PRNG keystream)
        {
            List<byte> functionReturnValue = default(List<byte>);
            functionReturnValue = new List<byte>();

            foreach (byte c in data)
            {
                functionReturnValue.Add((byte)((c ^ keystream.NextNum()) & 0xff));
            }
            return functionReturnValue;
        }

        List<string> PKMfromFolder;
        int CountPKMfromFolder;

        private void button1_Click(object sender, EventArgs e)
        {
            BT_GTS.Enabled = false;
            if (!BGW_GTS.IsBusy)
            {
                LB_GTS_Log.Items.Add(DateTime.Now.ToLongTimeString() + ": Sending command: Start GTS");
                LB_GTS_Log.SelectedIndex = LB_GTS_Log.Items.Count - 1;
                currentDataFileName = "";
                if (CB_GTS_SendPKMN.Checked && RB_GTS_SendFolder.Checked)
                {
                    if (!Directory.Exists(TB_GTS_SendPKMN.Text))
                    {
                        MessageBox.Show("The folder you have selected does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        BT_GTS.Enabled = true;
                        return;
                    }
                    PKMfromFolder = new List<string>();
                    PKMfromFolder.AddRange(Directory.GetFiles(TB_GTS_SendPKMN.Text));
                    CountPKMfromFolder = PKMfromFolder.Count;
                    if (PKMfromFolder.Count > 0)
                    {
                        FileInfo FI = new FileInfo(PKMfromFolder[0]);
                        LB_GTS_Log.Items.Add(DateTime.Now.ToLongTimeString() + ": " + "Next Pkm (1 of " + CountPKMfromFolder + "): " + FI.Name);
                        LB_GTS_Log.SelectedIndex = LB_GTS_Log.Items.Count - 1;

                    }
                    else
                    {
                        MessageBox.Show("There are no .pkm-files in the folder.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CB_GTS_SendPKMN.Checked = false;
                        TB_GTS_SendPKMN.Text = "";
                    }
                }
                if (CB_GTS_SendPKMN.Checked && RB_GTS_SendOne.Checked && !File.Exists(TB_GTS_SendPKMN.Text))
                {
                    MessageBox.Show("The file you have selected does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    BT_GTS.Enabled = true;
                    return;
                }
                BT_GTS.Text = "STOP GTS";

                CB_GTS_SendPKMN.Enabled = CB_GTS_Reject.Enabled = CB_GTS_SendAfterReceive.Enabled = RB_GTS_SendOne.Enabled = RB_GTS_SendFolder.Enabled = false;
                TB_GTS_SendPKMN.Enabled = BT_GTS_SendPKMN.Enabled = false;
                BGW_GTS.RunWorkerAsync();
                LA_GTS_Status.Text = "GTS running";
                LA_GTS_Status.BackColor = Color.Green;
                BT_GTS.Enabled = true;
            }
            else
            {
                BGW_GTS.ReportProgress(1, "Sending command: Stop GTS");
                BGW_GTS.CancelAsync();
            }
        }

        private void BGW_GTS_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            switch (e.ProgressPercentage)
            {
                case 2:
                    CB_GTS_SendPKMN.Checked = true;
                    RB_GTS_SendOne.Checked = true;
                    TB_GTS_SendPKMN.Text = e.UserState.ToString();
                    break;
                case 3:
                    CB_GTS_SendPKMN.Checked = false;
                    break;
                default:
                    LB_GTS_Log.Items.Add(DateTime.Now.ToLongTimeString() + ": " + e.UserState.ToString());
                    LB_GTS_Log.SelectedIndex = LB_GTS_Log.Items.Count - 1;
                    break;
            }
        }

        private void CB_GTS_SendPKMN_CheckedChanged(object sender, EventArgs e)
        {
            if (!BGW_GTS.IsBusy)
            {
                TB_GTS_SendPKMN.Enabled = CB_GTS_SendPKMN.Checked;
                BT_GTS_SendPKMN.Enabled = CB_GTS_SendPKMN.Checked;
                RB_GTS_SendFolder.Enabled = CB_GTS_SendPKMN.Checked;
                RB_GTS_SendOne.Enabled = CB_GTS_SendPKMN.Checked;
            }
        }

        private void BGW_GTS_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            LB_GTS_Log.Items.Add(DateTime.Now.ToLongTimeString() + ": GTS stopped.");
            LB_GTS_Log.SelectedIndex = LB_GTS_Log.Items.Count - 1;
            CB_GTS_SendPKMN.Enabled = CB_GTS_Reject.Enabled = CB_GTS_SendAfterReceive.Enabled = true;
            TB_GTS_SendPKMN.Enabled = BT_GTS_SendPKMN.Enabled = true;
            if (CB_GTS_SendPKMN.Checked)
                RB_GTS_SendFolder.Enabled = RB_GTS_SendOne.Enabled= true;
            else
                RB_GTS_SendFolder.Enabled = RB_GTS_SendOne.Enabled = false;

            LA_GTS_Status.Text = "GTS stopped";
            LA_GTS_Status.BackColor = Color.Red;
            BT_GTS.Text = "START GTS";
            BT_GTS.Enabled = true;
        }

        private void LL_GTS_clearLog_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LB_GTS_Log.Items.Clear();
            LB_GTS_Log.Items.Add(DateTime.Now.ToLongTimeString() + ": Log cleared.");
            LB_GTS_Log.SelectedIndex = LB_GTS_Log.Items.Count - 1;

        }

        private void LL_Help_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string Message;
            Message = "How to use:" + Environment.NewLine;
            Message += "" + Environment.NewLine;
            Message += "* Check if the correct IP is shown in the Textbox" + Environment.NewLine;
            Message += "* Start DNS" + Environment.NewLine;
            Message += "* If you want to send a PKMN from a .pkm-File check the box" + Environment.NewLine;
            Message += "  and choose the file. It will be sent to any DS that connects. " + Environment.NewLine;
            Message += "* If you want to send more than one PKMN from .pkm-Files check the box";
            Message += "  and choose the folder. Everytime a DS connects one PKMN will be sent until all files in the folder have been sent. " + Environment.NewLine;
            Message += "" + Environment.NewLine;
            Message += "Receive Pokemon:" + Environment.NewLine;
            Message += "* Reject the Pokemon: The DS thinks that the Server rejects the PKMN" + Environment.NewLine;
            Message += "  so it will not delete it." + Environment.NewLine;
            Message += "* Send after receiving is perfect for cloning Pokemon. You can send" + Environment.NewLine;
            Message += "  a Pokemon to the server and receive it as often as you want: Just enter" + Environment.NewLine;
            Message += "  the GTS (you will get the Pokemon), exit and enter again as often as you want." + Environment.NewLine;
            Message += "" + Environment.NewLine;
            Message += "  Then start the GTS, set the DNS of the DS to the IP of the computer and connect to the GTS." + Environment.NewLine;
            Message += "" + Environment.NewLine;
            Message += "---" + Environment.NewLine;
            Message += "Thx to M@T, LordLandon, Eevee and many other users of projectpokemon.org" + Environment.NewLine;
            MessageBox.Show(Message, "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void RB_GTS_SendOne_CheckedChanged(object sender, EventArgs e)
        {
            if (RB_GTS_SendOne.Checked)
                TB_GTS_SendPKMN.Text = "";
        }

        private void RB_GTS_SendFolder_CheckedChanged(object sender, EventArgs e)
        {
            if (RB_GTS_SendFolder.Checked)
                TB_GTS_SendPKMN.Text = Application.StartupPath + "\\PKMs\\";
        }





    }
}