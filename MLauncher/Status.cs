using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MLauncher
{
    class Status
    {
        ServerInfo serverInfo;
        List<PlayerInfo> playersInfo;

        internal ServerInfo ServerInfo { get => serverInfo; set => serverInfo = value; }
        internal List<PlayerInfo> PlayersInfo { get => playersInfo; set => playersInfo = value; }

        public Status()
        {
            this.ServerInfo = null;
            this.PlayersInfo = new List<PlayerInfo>();
        }

        public void UpdateStatus()
        {
            string[] status = GetStatus();
            ServerInfo = new ServerInfo(status[8], status[10], status[12],
                Int32.Parse(status[16]), Int32.Parse(status[18]),
                status[28], Convert.ToBoolean(Int32.Parse(status[54])));
            PlayersInfo = new List<PlayerInfo>();
            string[] separator = { "player_" };
            string[] players = GetStatusPlayers().Split(separator, 
                System.StringSplitOptions.RemoveEmptyEntries);
            foreach (var player in players)
            {
                string[] stat = player.Split('\\');
                PlayerInfo playerInfo;
                if (this.ServerInfo.Numplayers <= 14)
                {
                    playerInfo = new PlayerInfo(Int32.Parse(stat[0]), stat[1],
                        Int32.Parse(stat[3]), Int32.Parse(stat[5]), stat[7],
                         (stat[9].Contains("1") ? "CONS" : "IGI"));
                }
                else
                {
                    playerInfo = new PlayerInfo(Int32.Parse(stat[0]), stat[1],
                        stat[7], (stat[9].Contains("1") ? "CONS" : "IGI"));
                }
                this.PlayersInfo.Add(playerInfo);
            }
        }

        public void CheckStatus()
        {
            Main.status.UpdateStatus();
            int players = Main.status.ServerInfo.Numplayers;
            do
            {
                Main.status.UpdateStatus();
                Main.launcher.SetStatusInvoke();
                if (Main.dane.Notify)
                {
                    if (Main.status.serverInfo.Numplayers > players)
                    {
                        players = Main.status.serverInfo.Numplayers;
                        MessageBox.Show("New player on server!", "New player!");
                    }
                    else
                    {
                        players = Main.status.serverInfo.Numplayers;
                    }
                }
                Thread.Sleep(5000);
            }
            while (Main.dane.Login);

        }

        public static string[] GetStatus()
        {
            var values = new NameValueCollection();
            values["email"] = Main.dane.Email;
            values["word"] = Main.dane.Pass;
            string odp = Main.PostRequest("http://185.238.74.50/mlauncher/getStatus.php", values);
            return odp.Split('\\');
        }

        public static string GetStatusString()
        {
            var values = new NameValueCollection();
            values["email"] = Main.dane.Email;
            values["word"] = Main.dane.Pass;
            return Main.PostRequest("http://185.238.74.50/mlauncher/getStatus.php", values);
            
        }

        public static string GetStatusPlayers()
        {
            var values = new NameValueCollection();
            values["email"] = Main.dane.Email;
            values["word"] = Main.dane.Pass;
            string status = Main.PostRequest("http://185.238.74.50/mlauncher/getStatus.php", values);
            if(status.IndexOf("player_") < 0)
            {
                return "";
            } else
            {
                return status.Substring(status.IndexOf("player_"), status.IndexOf("\\final\\") - status.IndexOf("player_"));
            }

        }

    }
}
