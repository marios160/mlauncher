using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MLauncher
{
    class Dane
    {
        public string path;
        public string email;
        public string pass;
        public bool login;
        public string nick;


        public Dane()
        {
            this.path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            login = false;
            nick = "MJones";
        }

        public bool CheckRootFiles()
        {
            if (!File.Exists(path + "\\igi2.exe"))
            {
                MessageBox.Show("igi2.exe not exist!\n" +
                    "Place Mlauncher in IGI2 pc");
                return false;
            }
            else if (!File.Exists(path + "\\config.qvm"))
            {
                MessageBox.Show("config.qvm not exist!\n" +
                    "Place Mlauncher in IGI2 pc");
                return false;
            }
            else if (!File.Exists(path + "\\vqdll.dll"))
            {
                MessageBox.Show("vqdll.dll not exist!\n" +
                    "Place Mlauncher in IGI2 pc");
                return false;
            }
            else if (!File.Exists(path + "\\lod.qvm"))
            {
                MessageBox.Show("lod.qvm not exist!\n" +
                    "Place Mlauncher in IGI2 pc");
                return false;
            }
            else if (!File.Exists(path + "\\mss32.dll"))
            {
                MessageBox.Show("mss32.dll not exist!\n" +
                    "Place Mlauncher in IGI2 pc");
                return false;
            }
            return true;
        }
    }
}
