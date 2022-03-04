using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MLauncher
{
    [Serializable]
    class Dane
    {
        private string path;
        private string email;
        private string pass;
        private bool login;
        private string nick;
        private bool notify;


        public Dane()
        {
            this.Path = System.IO.Path.GetDirectoryName(
                System.Reflection.Assembly.GetExecutingAssembly().Location);
            Login = false;
            Nick = "MJones";
            Email = "";
            Pass = "";
            Notify = false;

        }

        public string Nick { get => nick; set => nick = value; }
        public bool Login { get => login; set => login = value; }
        public string Pass { get => pass; set => pass = value; }
        public string Email { get => email; set => email = value; }
        public string Path { get => path; set => path = value; }
        public bool Notify { get => notify; set => notify = value; }

        public bool CheckRootFiles()
        {
            if (!File.Exists(Path + "\\igi2.exe"))
            {
                MessageBox.Show("igi2.exe not exist!\n" +
                    "Place Mlauncher in IGI2 pc");
                return false;
            }
            else if (!File.Exists(Path + "\\config.qvm"))
            {
                MessageBox.Show("config.qvm not exist!\n" +
                    "Place Mlauncher in IGI2 pc");
                return false;
            }
            else if (!File.Exists(Path + "\\vqdll.dll"))
            {
                MessageBox.Show("vqdll.dll not exist!\n" +
                    "Place Mlauncher in IGI2 pc");
                return false;
            }
            else if (!File.Exists(Path + "\\lod.qvm"))
            {
                MessageBox.Show("lod.qvm not exist!\n" +
                    "Place Mlauncher in IGI2 pc");
                return false;
            }
            else if (!File.Exists(Path + "\\mss32.dll"))
            {
                MessageBox.Show("mss32.dll not exist!\n" +
                    "Place Mlauncher in IGI2 pc");
                return false;
            }
            return true;
        }
        
        public void Zakoduj()
        {
            this.path = Main.Zakoduj("mlauncher", this.path);
            this.email = Main.Zakoduj("mlauncher", this.email);
            this.pass = Main.Zakoduj("mlauncher", this.pass);
            this.nick = Main.Zakoduj("mlauncher", this.nick);

        }

        public void Odkoduj()
        {
            this.path = Main.Odkoduj("mlauncher", this.path);
            this.email = Main.Odkoduj("mlauncher", this.email);
            this.pass = Main.Odkoduj("mlauncher", this.pass);
            this.nick = Main.Odkoduj("mlauncher", this.nick);

        }


    }
}
