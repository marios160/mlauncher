using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLauncher
{
    class ServerInfo
    {
        string hostname;
        string hostport;
        string mapname;
        int numplayers;
        int maxplayers;
        string timeleft;
        bool password;

        public ServerInfo(string hostname, string hostport, string mapname, int numplayers, int maxplayers, string timeleft, bool password)
        {
            this.Hostname = hostname;
            this.Hostport = hostport;
            this.Mapname = mapname;
            this.Numplayers = numplayers;
            this.Maxplayers = maxplayers;
            this.Timeleft = timeleft;
            this.Password = password;
        }

        public string Hostname { get => hostname; set => hostname = value; }
        public string Hostport { get => hostport; set => hostport = value; }
        public string Mapname { get => mapname; set => mapname = value; }
        public int Numplayers { get => numplayers; set => numplayers = value; }
        public int Maxplayers { get => maxplayers; set => maxplayers = value; }
        public string Timeleft { get => timeleft; set => timeleft = value; }
        public bool Password { get => password; set => password = value; }
    }
}
