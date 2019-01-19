using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MLauncher
{
    public partial class InputBox : Form
    {
        static string response;
        public InputBox(string title, string text)
        {
            InitializeComponent();
            lblText.Text = text;
            this.Text = title;
        }

        static public string show(string title, string text)
        {
            response = "";
            new InputBox(title, text).ShowDialog();
            return response; 
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            response = txtInput.Text;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            response = "";
            Close();
        }

        private void txtInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnOk_Click(new object(), new EventArgs());
            }
        }
    }
}
