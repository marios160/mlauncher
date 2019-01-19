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
    public partial class Logowanie : Form
    {
        public Logowanie()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            new Rejestracja().ShowDialog();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            btnLogin.Text = "Checking...";
            btnLogin.Focus();
            lblPass.ForeColor = Color.Green;
            lblPass.Font = new Font(lblPass.Font, FontStyle.Bold);
            using (var client = new WebClient())
            {
                var values = new NameValueCollection();
                values["email"] = txtEmail.Text;
                values["word"] = M.CalculateMD5Hash(txtPass.Text);
                values["cdk"] = M.CalculateMD5Hash(RegistryCDK.getCDK());

                var response = client.UploadValues("http://185.238.74.50/mlauncher/login.php", values);
                var responseString = Encoding.Default.GetString(response);
                if (responseString.Equals("Not activated!"))
                {
                    do
                    {
                        values = new NameValueCollection();
                        values["email"] = txtEmail.Text;
                        values["activatedCode"] = InputBox.show("Activation code", "Enter activation code from email message:");
                        if (values["activatedCode"] == "")
                        {
                            break;
                        }
                        response = client.UploadValues("http://185.238.74.50/mlauncher/activate.php", values);
                        responseString = Encoding.Default.GetString(response);
                        MessageBox.Show(responseString);
                    } while (!responseString.Equals("Activated!"));
                    M.dane.login = false;

                }
                else if(responseString.Contains("nick="))
                {
                    string nick = responseString.Substring(responseString.IndexOf("nick=") + 5, responseString.IndexOf("=kcin") - 5);
                    M.dane.login = true;
                    M.dane.email = txtEmail.Text;
                    M.dane.nick = nick;
                    M.dane.pass = M.CalculateMD5Hash(txtPass.Text);
                    this.Close();
                }
                else if (responseString.Contains("cdk="))
                {
                    string cdk = responseString.Substring(responseString.IndexOf("cdk=") + 4, 19);
                    RegistryCDK.removeCDK();
                    RegistryCDK.addCDK(cdk,M.dane.path);
                    M.dane.login = true;
                    this.Close();
                }
                else
                {
                    M.dane.login = false;
                    MessageBox.Show(responseString);
                }

            }
            btnLogin.Text = "Login";
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            bool result = ValidatorExtensions.IsValidEmailAddress(txtEmail.Text);
            if (!result)
            {
                lblEmail.ForeColor = Color.Red;
                lblEmail.Font = new Font(lblEmail.Font, FontStyle.Bold);
                btnLogin.Enabled = false;
                lblEmailWrong.Visible = true;
            }
            else
            {
                lblEmail.ForeColor = Color.Green;
                lblEmail.Font = new Font(lblEmail.Font, FontStyle.Bold);
                btnLogin.Enabled = true;
                lblEmailWrong.Visible = false;
            }
        }

        private void txtPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13 && btnLogin.Enabled)
            {
                btnLogin.Text = "Checking...";
                btnLogin.Focus();
                btnLogin_Click(new object(), new EventArgs());
            }
        }
    }
}
