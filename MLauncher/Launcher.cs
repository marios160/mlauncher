using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MLauncher
{
    public partial class Launcher : Form
    {
        public Launcher()
        {
            InitializeComponent();
            lblVersion.Text = "version " + Main.version;
            lblEmail.Text = Main.dane.Email;
            txtNick.Text = Main.dane.Nick;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Main.dane.Login = false;
            Main.dane.Zakoduj();
            Main.Serialize(Main.dane);
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(Main.dane.Nick == txtNick.Text)
            {
                return;
            }

            Main.dane.Nick = txtNick.Text;
            var client = new WebClient();

            var values = new NameValueCollection();
            values["email"] = Main.dane.Email;
            values["word"] = Main.dane.Pass;
            values["nick"] = Main.dane.Nick;
            var response = client.UploadValues("http://185.238.74.50/mlauncher/changeNick.php", values);
            var responseString = Encoding.Default.GetString(response);
            MessageBox.Show(responseString);
            
        }

        public void btnStatus_Click(object sender, EventArgs e)
        {
            SetStatus();
        }

        private void btnJoin_Click(object sender, EventArgs e)
        {
            chbNofity.Checked = false;
            var client = new WebClient();
            var values = new NameValueCollection();
            values["email"] = Main.dane.Email;
            values["word"] = Main.dane.Pass;
            var response = client.UploadValues(
                "http://185.238.74.50/mlauncher/join.php", values);
            var responseString = Encoding.Default.GetString(response);
            if (responseString.Equals("JOIN!"))
            {
                System.Diagnostics.Process.Start("igi2.exe", 
                    "ip185.238.74.50 port" + lblHostport.Text 
                    + " player\"" + Main.dane.Nick + "\"");
            }
        }

        private void chbNofity_CheckedChanged(object sender, EventArgs e)
        {
            Main.dane.Notify = chbNofity.Checked;     
        }

        public void SetStatus()
        {

                lblHostname.Text = Main.status.ServerInfo.Hostname;
                lblHostport.Text = Main.status.ServerInfo.Hostport;
                lblTimeleft.Text = Main.status.ServerInfo.Timeleft;
                lblMapname.Text = Main.status.ServerInfo.Mapname;
                lblNumplayers.Text = Main.status.ServerInfo.Numplayers.ToString();
                lblMaxplayers.Text = Main.status.ServerInfo.Maxplayers.ToString();
            lstPlayers.Items.Clear();
            foreach (var player in Main.status.PlayersInfo)
            {
                string[] row = { player.Id.ToString(), player.Nick, player.Kills.ToString(), player.Deaths.ToString(), player.Ping, player.Team};
                lstPlayers.Items.Add(new ListViewItem(row));
            }

        }

        public void SetStatusInvoke()
        {
            try
            {
                lblHostname.Invoke(new Action(() => lblHostname.Text = Main.status.ServerInfo.Hostname));
                lblHostport.Invoke(new Action(() => lblHostport.Text = Main.status.ServerInfo.Hostport));
                lblTimeleft.Invoke(new Action(() => lblTimeleft.Text = Main.status.ServerInfo.Timeleft));
                lblMapname.Invoke(new Action(() => lblMapname.Text = Main.status.ServerInfo.Mapname));
                lblNumplayers.Invoke(new Action(() => lblNumplayers.Text = Main.status.ServerInfo.Numplayers.ToString()));
                lblMaxplayers.Invoke(new Action(() => lblMaxplayers.Text = Main.status.ServerInfo.Maxplayers.ToString()));
                lstPlayers.Invoke(new Action(() => lstPlayers.Items.Clear()));
                foreach (var player in Main.status.PlayersInfo)
                {
                    string[] row = { player.Id.ToString(), player.Nick, player.Kills.ToString(), player.Deaths.ToString(), player.Ping, player.Team };
                    lstPlayers.Invoke(new Action(() =>  lstPlayers.Items.Add(new ListViewItem(row))));
                }
            }
            catch (Exception)
            {
                if(Main.statusThread != null)
                {
                    Main.statusThread.Abort();
                } 
                
            }
        }

        
        
    }
}
