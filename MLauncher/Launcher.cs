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
            SetStatus(Status.GetStatus());
            lblVersion.Text = "version " + M.version;
            lblEmail.Text = M.dane.Email;
            txtNick.Text = M.dane.Nick;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            M.dane.Login = false;
            M.dane.Zakoduj();
            M.Serialize(M.dane);
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(M.dane.Nick == txtNick.Text)
            {
                return;
            }

            M.dane.Nick = txtNick.Text;
            var client = new WebClient();

            var values = new NameValueCollection();
            values["email"] = M.dane.Email;
            values["word"] = M.dane.Pass;
            values["nick"] = M.dane.Nick;
            var response = client.UploadValues("http://185.238.74.50/mlauncher/changeNick.php", values);
            var responseString = Encoding.Default.GetString(response);
            MessageBox.Show(responseString);
            
        }

        public void btnStatus_Click(object sender, EventArgs e)
        {
            SetStatus(Status.GetStatus());
        }

        private void btnJoin_Click(object sender, EventArgs e)
        {
            chbNofity.Checked = false;
            var client = new WebClient();
            var values = new NameValueCollection();
            values["email"] = M.dane.Email;
            values["word"] = M.dane.Pass;
            var response = client.UploadValues("http://185.238.74.50/mlauncher/join.php", values);
            var responseString = Encoding.Default.GetString(response);
            if (responseString.Equals("JOIN!"))
            {
                System.Diagnostics.Process.Start("igi2.exe", "ip185.238.74.50 port" + lblHostport.Text + " player\"" + M.dane.Nick + "\"");
            }
        }

        private void chbNofity_CheckedChanged(object sender, EventArgs e)
        {
            M.dane.Notify = chbNofity.Checked;
            if (chbNofity.Checked)
            {
                Console.WriteLine("Sprawdzanie true");

                Status status = new Status();
                M.nofifyThread = new Thread(new ThreadStart(status.CheckStatus));
                M.nofifyThread.Start();
                
            } else
            {
                Console.WriteLine("Sprawdzanie false null");

                if (M.nofifyThread != null)
                {
                    Console.WriteLine("Sprawdzanie false");

                    M.nofifyThread.Abort();
                    M.nofifyThread = null;
                }
            }
                
        }

        public void SetStatus(string[] status)
        {
          
                lblHostname.Text = status[8];
                lblHostport.Text = status[10];
                lblTimeleft.Text = status[28];
                lblMapname.Text = status[12];
                lblNumplayers.Text = status[16];
                lblMaxplayers.Text = status[18];

        }

        public void SetStatusInvoke(string [] status)
        {
            try
            {

                lblHostname.Invoke(new Action(()=>lblHostname.Text = status[8]));
                lblHostport.Invoke(new Action(delegate ()
                {
                    lblHostport.Text = status[10];
                }));
                lblTimeleft.Invoke(new Action(delegate ()
                {
                    lblTimeleft.Text = status[28];
                }));
                lblMapname.Invoke(new Action(delegate ()
                {
                    lblMapname.Text = status[12];
                }));
                lblNumplayers.Invoke(new Action(delegate ()
                {
                    lblNumplayers.Text = status[16];
                }));
                lblMaxplayers.Invoke(new Action(delegate ()
                {
                    lblMaxplayers.Text = status[18];
                }));
            }
            catch (Exception)
            {
                if(M.nofifyThread != null)
                {
                    M.nofifyThread.Abort();
                } 
                
            }
        }

        
        
    }
}
