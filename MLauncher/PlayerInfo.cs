using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLauncher
{
    class PlayerInfo
    {
        int id;
        string nick;
        int kills;
        int deaths;
        string ping;
        string team;

        public PlayerInfo(int id, string nick, int kills, int deaths, string ping, string team)
        {
            this.id = id;
            this.nick = nick;
            this.kills = kills;
            this.deaths = deaths;
            this.ping = ping;
            this.team = team;
        }

        public PlayerInfo(int id, string nick, string ping, string team)
        {
            this.id = id;
            this.nick = nick;
            this.kills = 0;
            this.deaths = 0;
            this.ping = ping;
            this.team = team;
        }

        public int Id { get => id; set => id = value; }
        public string Nick { get => nick; set => nick = value; }
        public int Kills { get => kills; set => kills = value; }
        public int Deaths { get => deaths; set => deaths = value; }
        public string Ping { get => ping; set => ping = value; }
        public string Team { get => team; set => team = value; }
    }
}
