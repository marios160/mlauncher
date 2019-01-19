using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MLauncher
{
    public partial class Launcher : Form
    {
        public Launcher()
        {
            InitializeComponent();
            lblEmail.Text = M.dane.email;
            txtNick.Text = M.dane.nick;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(M.dane.nick == txtNick.Text)
            {
                return;
            }

            M.dane.nick = txtNick.Text;
            var client = new WebClient();

            var values = new NameValueCollection();
            values["email"] = M.dane.email;
            values["word"] = M.dane.pass;
            values["nick"] = M.dane.nick;
            var response = client.UploadValues("http://185.238.74.50/mlauncher/changeNick.php", values);
            var responseString = Encoding.Default.GetString(response);
            MessageBox.Show(responseString);
            
        }

        private void btnStatus_Click(object sender, EventArgs e)
        {
            var client = new WebClient();
            var values = new NameValueCollection();
            values["email"] = M.dane.email;
            values["word"] = M.dane.pass;
            var response = client.UploadValues("http://185.238.74.50/mlauncher/getStatus.php", values);
            var responseString = Encoding.Default.GetString(response);
            var status = responseString.Split('\\');
            lblHostname.Text = status[8];
            lblHostport.Text = status[10];
            lblMapname.Text = status[12];
            lblNumplayers.Text = status[16];
            lblMaxplayers.Text = status[18];
            lblTimeleft.Text = status[28];
            
        }

        private void btnJoin_Click(object sender, EventArgs e)
        {
            var client = new WebClient();
            var values = new NameValueCollection();
            values["email"] = M.dane.email;
            values["word"] = M.dane.pass;
            var response = client.UploadValues("http://185.238.74.50/mlauncher/join.php", values);
            var responseString = Encoding.Default.GetString(response);
            if (responseString.Equals("JOIN!"))
            {
                System.Diagnostics.Process.Start("igi2.exe", "ip185.238.74.50 port" + lblHostport.Text + " player\"" + M.dane.nick + "\"");
            }
        }
    }
}
