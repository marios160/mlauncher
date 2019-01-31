using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace MLauncher
{
    public partial class Rejestracja : Form
    {

        public Rejestracja()
        {
            InitializeComponent();
        }



        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtPass1.Text.Equals(txtPass2.Text))
            {
                btnRegister.Text = "Registration...";
                lblPass2.ForeColor = Color.Green;
                lblPass2.Font = new Font(lblPass2.Font, FontStyle.Bold);
                lblPassWrong2.Visible = false;
                Random random = new Random();
                const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                String cdk1 =  new string(Enumerable.Repeat(chars, 4).Select(s => s[random.Next(s.Length)]).ToArray());
                String cdk2 = new string(Enumerable.Repeat(chars, 4).Select(s => s[random.Next(s.Length)]).ToArray());
                String cdk3 = new string(Enumerable.Repeat(chars, 4).Select(s => s[random.Next(s.Length)]).ToArray());
                String cdk4 =  new string(Enumerable.Repeat(chars, 4).Select(s => s[random.Next(s.Length)]).ToArray());
                String cdk = cdk1 + "-" + cdk2 + "-" + cdk3 + "-" + cdk4;
                String md5cdk = M.CalculateMD5Hash(cdk);


                using (var client = new WebClient())
                {
                    var values = new NameValueCollection();
                    values["email"] = txtEmail.Text;
                    values["word"] = M.CalculateMD5Hash(txtPass1.Text);
                    values["cdk"] = md5cdk;
                    values["rawcdk"] = cdk;

                    var response = client.UploadValues("http://185.238.74.50/mlauncher/register.php", values);
                    var responseString = Encoding.Default.GetString(response);
                    if (responseString.Equals("User created!"))
                    {

                        //sprawdzenie i dodanie Klucza cdkey
                        if (RegistryCDK.ExistCDK())
                        {
                            RegistryCDK.ChangeCDK(cdk);
                            RegistryCDK.ChangePath(M.dane.Path);
                        }
                        else
                        {
                            RegistryCDK.AddCDK(cdk, M.dane.Path);
                        }

                        do
                        {
                            values = new NameValueCollection();
                            values["email"] = txtEmail.Text;
                            values["activatedCode"] = InputBox.Show("Activation code", "Enter activation code from email message:");
                            if(values["activatedCode"] == "")
                            {
                                break;
                            }
                            response = client.UploadValues("http://185.238.74.50/mlauncher/activate.php", values);
                            responseString = Encoding.Default.GetString(response);
                            MessageBox.Show(responseString);
                        } while (!responseString.Equals("Activated!"));

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(responseString);
                    }

                }

            }
            else
            {
                lblPass2.ForeColor = Color.Red;
                lblPass2.Font = new Font(lblPass2.Font, FontStyle.Bold);
                lblPassWrong2.Visible = true;
            }
            btnRegister.Text = "Register";
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            bool result = ValidatorExtensions.IsValidEmailAddress(txtEmail.Text);
            if (!result)
            {
                lblEmail.ForeColor = Color.Red;
                lblEmail.Font = new Font(lblEmail.Font, FontStyle.Bold);
                btnRegister.Enabled = false;
                lblEmailWrong.Visible = true;
            }
            else
            {
                lblEmail.ForeColor = Color.Green;
                lblEmail.Font = new Font(lblEmail.Font, FontStyle.Bold);
                if (ValidatorExtensions.IsValidPassword(txtPass1.Text))
                {
                    btnRegister.Enabled = true;
                }
                lblEmailWrong.Visible = false;
            }
        }

        private void txtPass1_Leave(object sender, EventArgs e)
        {
            bool result = ValidatorExtensions.IsValidPassword(txtPass1.Text);
            if (!result)
            {
                lblPass1.ForeColor = Color.Red;
                lblPass1.Font = new Font(lblPass1.Font, FontStyle.Bold);
                btnRegister.Enabled = false;
                lblPassWrong.Visible = true;
            }
            else
            {
                lblPass1.ForeColor = Color.Green;
                lblPass1.Font = new Font(lblPass1.Font, FontStyle.Bold);
                if (ValidatorExtensions.IsValidEmailAddress(txtEmail.Text))
                {
                    btnRegister.Enabled = true;
                }
                lblPassWrong.Visible = false;
            }
        }

        private void txtPass2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13 && btnRegister.Enabled)
            {
                btnRegister_Click(new object(), new EventArgs());
            }
        }
    }
}
