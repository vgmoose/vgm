using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Text;
using System.Text.RegularExpressions;
using System;

static class Module1
{

    static Socket dnsserv;
    static Socket s;

    //static //ConsoleColor defColor = //Console.ForegroundColor;

    static string fake_ip = "";

    static bool mustLog = false;
    static string log = "logDNS.log";

    //DNS server to use to resolve hostnames :
    //Const DEFAULT_DNS_SERVER As String = "10.4.1.79"
    //Const DEFAULT_DNS_SERVER As String = "4.2.2.2"
    const string DEFAULT_DNS_SERVER = "208.67.222.222";

    private static bool IsIP(string ip)
    {
        Regex rIP = new Regex("^(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$");
        return rIP.IsMatch(ip);
    }

    public static void OldMain(string[] args)
    {

        if (args.Length() > 0)
        {
            if (args.Length() > 1)
            {
                ////Console.WriteLine("Too many parameters ! Using the first one as the IP of the fake GTS server.");
                //Console.WriteLine();
            }

            fake_ip = args[0];
        }

        while (!(IsIP(fake_ip)))
        {
            if (!string.IsNullOrEmpty(fake_ip))
            {
                //Console.WriteLine("This is not a valid IP address !");
            }

            //Console.Write("Please enter the IP of the fake GTS server : ");
            //fake_ip = Console.ReadLine();
        }
        //Console.WriteLine();


        Thread thr = new Thread(dnsspoof);
        thr.Start();
    }


    private static void dnsspoof()
    {
        dnsserv = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        dnsserv.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, 1);
        
        dnsserv.Bind(new IPEndPoint(IPAddress.Any, 53));
        
        //Console.Write("DNS server started on ");
        //Console.ForegroundColor = //ConsoleColor.Blue;
        //Console.WriteLine(((IPEndPoint)dnsserv.LocalEndPoint).ToString);
        //Console.ForegroundColor = defColor;
        //Console.WriteLine();
        
        
        if (mustLog && File.Exists(log) && File.ReadAllBytes(log).Length > 0) {
            File.AppendAllText(log, "----------------------------------------" + Environment.NewLine + Environment.NewLine);
        }
        
        if (mustLog) File.AppendAllText(log, "DNS server started on " + ((IPEndPoint)dnsserv.LocalEndPoint).ToString() + Environment.NewLine + Environment.NewLine); 
        
        byte[] fake_ip_byte = new byte[4];
        for (int i = 0; i <= 3; i++) {
            fake_ip_byte[i] = byte.Parse(fake_ip.Split('.')[i]);
        }
        
        byte[] r;
        byte[] rr = new byte[512];
        //, rr_fake(511)
        int lngSnd = 0;
        int lngRcv = 0;
        string str_r = null;
        string str_rr = null;
        string host = null;
        
        EndPoint rem_ep = new IPEndPoint(IPAddress.Any, 0);
        
        while (true) {
            try {
                 // ERROR: Not supported in C#: ReDimStatement

                r = new byte[511];
                lngRcv = dnsserv.ReceiveFrom(r, SocketFlags.None, ref rem_ep);
                r = new byte[lngRcv];
                Array.Resize(ref r, lngRcv + 1);
                
                str_r = Encoding.ASCII.GetString(r, 0, lngRcv);
                
                //Console.WriteLine("Data from : " + ((IPEndPoint)rem_ep).ToString);
                ////Console.WriteLine(str_r)
                
                if (mustLog) File.AppendAllText(log, "Data from : " + ((IPEndPoint)rem_ep).ToString() + Environment.NewLine + str_r + Environment.NewLine + Environment.NewLine, Encoding.ASCII); 
                
                host = str_r.Substring(12, str_r.IndexOf(Strings.Chr(0), 12) - 12);
                
                string requestedHost = "";
                int n = 0;
                
                while (n < host.Length) {
                    requestedHost += host.Substring(n + 1, r(n + 12)) + ".";
                    n += r(n + 12) + 1;
                }
                requestedHost = requestedHost.Substring(0, requestedHost.Length - 1);
                
                //Console.WriteLine("Client requesting : " + requestedHost);
                
                if (mustLog) File.AppendAllText(log, "Client requesting : " + requestedHost + Environment.NewLine); 
                
                 // ERROR: Not supported in C#: ReDimStatement

                s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                s.Connect(DEFAULT_DNS_SERVER, 53);
                s.Send(r, lngRcv, SocketFlags.None);
                lngSnd = s.Receive(rr, SocketFlags.None);
                
                Array.Resize(ref rr, lngSnd + 1);
                
                if (mustLog) File.AppendAllText(log, "Real DNS server's answer : " + Environment.NewLine + Encoding.ASCII.GetString(rr, 0, lngSnd) + Environment.NewLine + Environment.NewLine, Encoding.ASCII); 
                
                //Checks if client is requesting 'gamestats2.gs.nintendowifi.net'
                //If str_r.Length > 43 AndAlso str_r.Substring(13, 30) = "gamestats2" & Chr(2) & "gs" & Chr(12) & "nintendowifi" & Chr(3) & "net" Then
                if (requestedHost == "gamestats2.gs.nintendowifi.net") {
                    //ReDim rr_fake(lngRcv + 15), rr(lngRcv + 15)
                    
                    //Array.Copy(r, 0, rr_fake, 0, 2)
                    //rr_fake(2) = &H81
                    //rr_fake(3) = &H80
                    //Array.Copy(r, 4, rr_fake, 4, 2)
                    //Array.Copy(r, 4, rr_fake, 6, 2)
                    //rr_fake(8) = &H0
                    //rr_fake(9) = &H0
                    //rr_fake(10) = &H0
                    //rr_fake(11) = &H0
                    //Array.Copy(r, 12, rr_fake, 12, lngRcv - 12)
                    //rr_fake(lngRcv) = &HC0
                    //rr_fake(lngRcv + 1) = &HC
                    //rr_fake(lngRcv + 2) = &H0
                    //rr_fake(lngRcv + 3) = &H1
                    //rr_fake(lngRcv + 4) = &H0
                    //rr_fake(lngRcv + 5) = &H1
                    //rr_fake(lngRcv + 6) = &H0
                    //rr_fake(lngRcv + 7) = &H0
                    //rr_fake(lngRcv + 8) = &H0
                    //rr_fake(lngRcv + 9) = &H3C
                    //rr_fake(lngRcv + 10) = &H0
                    //rr_fake(lngRcv + 11) = &H4
                    //Array.Copy(fake_ip_byte, 0, rr_fake, lngRcv + 12, 4)
                    //rr = rr_fake
                    //str_rr = Encoding.ASCII.GetString(rr, 0, lngRcv + 16)
                    
                    Array.Copy(fake_ip_byte, 0, rr, 0x3c, 4);
                    
                    //Console.ForegroundColor = //ConsoleColor.Green;
                    //Console.WriteLine("Spoofing : gamestats2.gs.nintendowifi.net -> " + fake_ip);
                    //Console.ForegroundColor = defColor;
                    
                    if (mustLog) File.AppendAllText(log, "Spoofing : gamestats2.gs.nintendowifi.net -> " + fake_ip + Environment.NewLine); 
                }
                
                str_rr = Encoding.ASCII.GetString(rr, 0, lngSnd);
                
                dnsserv.SendTo(rr, rr.Length, SocketFlags.None, rem_ep);
                //Console.WriteLine("Data sent to : " + ((IPEndPoint)rem_ep).ToString);
                ////Console.WriteLine(str_rr)
                
                if (mustLog) File.AppendAllText(log, "Data sent to : " + ((IPEndPoint)rem_ep).ToString + Environment.NewLine + str_rr + Environment.NewLine, Encoding.ASCII); 
                if (mustLog) File.AppendAllText(log, "------------------" + Environment.NewLine + Environment.NewLine); 
                
                //Console.WriteLine();
            }
            catch (Exception ex) {
                //Console.ForegroundColor = //ConsoleColor.Red;
                //Console.WriteLine("Error : " + ex.Message);
                //Console.ForegroundColor = defColor;
            }
        }
        
        dnsserv.Close();
        s.Close();
    }
}
