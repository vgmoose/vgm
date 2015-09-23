using System;
using System.Collections.Generic;
namespace HyperGTS
{
    public class PokePRNG
    {

        public PokePRNG()
        {
            m_seed = 0u;
        }

        public PokePRNG(UInt32 _SEED)
        {
            m_seed = _SEED;
        }

        private UInt32 m_seed;

        public UInt32 Seed
        {
            get { return m_seed; }
            set { m_seed = value; }
        }

        public UInt32 Previous()
        {
            return 0xeeb9eb65 * m_seed + 0xa3561a1;
        }

        public UInt32 PreviousNum()
        {
            m_seed = Previous();
            return m_seed;
        }

        public UInt32 Next()
        {
            return (0x41c64e6d * m_seed) + 0x6073;
        }

        public UInt32 NextNum()
        {
            m_seed = Next();
            return m_seed;
        }

    }

    public class GTS_PRNG
    {

        public GTS_PRNG()
        {
            m_seed = 0u;
        }

        public GTS_PRNG(UInt32 _SEED)
        {
            m_seed = _SEED | (_SEED << 16);
        }

        private UInt32 m_seed;

        public UInt32 Seed
        {
            get { return m_seed; }
            set { m_seed = value; }
        }

        public UInt32 Next()
        {
            return (m_seed * 0x45 + 0x1111) & 0x7fffffff;
        }

        public UInt32 NextNum()
        {
            m_seed = Next();
            return (m_seed >> 16) & 0xff;
        }

    }

    public class Request
    {
        public string action;
        public string page;
        public Dictionary<string, string> getvars;

        public Request()
        {
            action = null;
            page = null;
            getvars = new Dictionary<string, string>();
        }

        public Request(string h)
        {
            if (!h.StartsWith("GET"))
            {
                throw new Exception("Not a DS header !");
            }

            string request = "";

            request = h.Substring(h.IndexOf("/pokemondpds/") + 13, h.IndexOf("HTTP/1.1") - h.IndexOf("/pokemondpds/") - 14);

            page = request.Substring(0, request.IndexOf("?"));
            action = request.Substring(request.IndexOf("/") + 1, request.IndexOf(".asp?") - request.IndexOf("/") - 1);

            Dictionary<string, string> vars = new Dictionary<string, string>();

            foreach (string i in request.Substring(request.IndexOf("?") + 1).Split('&'))
            {
                vars.Add(i.Substring(0, i.IndexOf("=")), i.Substring(i.IndexOf("=") + 1));
            }

            getvars = vars;
        }

        public override string ToString()
        {
            string request = page + "?";

            foreach (KeyValuePair<string, string> i in getvars)
            {
                request += i.Key + "=" + i.Value + "&";
            }

            request = request.Substring(0, request.Length - 1);

            return "GET /pokemondpds/" + request + " HTTP/1.1\\r\\n" + "Host: gamestats2.gs.nintendowifi.net\\r\\nUser-Agent: GameSpyHTTP/1.0\\r\\n" + "Connection: close\\r\\n\\r\\n";
        }

        public string RequestedPage()
        {
            string RequestedPage1 = page + "?";

            foreach (KeyValuePair<string, string> i in getvars)
            {
                RequestedPage1 += i.Key + "=" + i.Value + "&";
            }

            return RequestedPage1.Substring(0, RequestedPage1.Length - 1);
        }
    }

    public class Response
    {
        string data;
        List<string> headers;

        string p3p;
        string server;
        string sname;
        string cookie;
        int len;

        public Response(string h)
        {
            if (!h.StartsWith("HTTP/1.1"))
            {
                data = h;
                return;
            }
            headers.AddRange(h.Split('\n'));

            string line = null;

            do
            {
                line = headers[0];
                headers.RemoveAt(0);

                if (line.StartsWith("P3P")) p3p = line.Substring(line.IndexOf(": ") + 2);
                if (line.StartsWith("cluster-server")) server = line.Substring(line.IndexOf(": ") + 2);
                if (line.StartsWith("X-Server-")) sname = line.Substring(line.IndexOf(": ") + 2);
                if (line.StartsWith("Content-Length")) len = int.Parse(line.Substring(line.IndexOf(": ") + 2));
                if (line.StartsWith("Set-Cookie")) cookie = line.Substring(line.IndexOf(": ") + 2);
            }
            while (!(string.IsNullOrEmpty(line)));

            data = string.Join(Environment.NewLine, headers.ToArray());
        }

        public override string ToString()
        {
            string[] months = { "???", "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", 
        "Oct", "Nov", "Dec" };
            string[] days = { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun" };

            System.DateTime t = DateTime.Now; ;

            //"Content-type: application/octet-stream" & vbCrLf & _
            return "HTTP/1.1 200 OK" + Environment.NewLine + "Date: " + days[(int)(t.DayOfWeek)] + ", " + t.Day + " " + t.Month + " " + t.Year + " " + t.Hour + ":" + t.Minute + ":" + t.Second + " GMT" + Environment.NewLine + "Server: Microsoft-IIS/6.0" + Environment.NewLine + "P3P: CP='NOI ADMa OUR STP'" + Environment.NewLine + "cluster-server: aphexweb3" + Environment.NewLine + "X-Server-Name: AW4" + Environment.NewLine + "X-Powered-By: ASP.NET" + Environment.NewLine + "Content-Length: " + data.Length + Environment.NewLine + "Content-Type: text/html" + Environment.NewLine + "Set-Cookie: ASPSESSIONIDQCDBDDQS=JFDOAMPAGACBDMLNLFBCCNCI; path=/" + Environment.NewLine + "Cache-control: private" + Environment.NewLine + Environment.NewLine + data;
        }

        public string[] getpkm()
        {
            List<string> all = new List<string>();
            string data_tmp = data;
            string result = "";

            while (data_tmp.Length > 0)
            {
                result = data.Substring(0, 292);
                data = data.Substring(292);
                all.Add(result.Substring(0, 136));
            }

            return all.ToArray();
        }
    }
}