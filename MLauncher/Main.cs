using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MLauncher
{
    static class Main
    {
        static public Dane dane;
        static public Thread statusThread;
        static public string version = "1.1.0";
        static public Launcher launcher;
        static public Status status;

        [STAThread]
        static void Main()
        {
            Console.WriteLine("Debug Console");
            if (CheckUpdates())
            {
                Update();
                return;
            }
            dane = (Dane)MLauncher.Main.Deserialize();
            if(dane == null)
            {
                dane = new Dane();
            }
            else
            {
                dane.Odkoduj();
            }


            if (!dane.CheckRootFiles())
            {
                return;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (!MLauncher.Main.dane.Login)
            {
                Application.Run(new Logowanie());
            }

            if (MLauncher.Main.dane.Login)
            {
                dane.Zakoduj();
                MLauncher.Main.Serialize(dane);
                dane.Odkoduj();
                launcher = new Launcher();
                MLauncher.Main.status = new Status();
                MLauncher.Main.statusThread = new Thread(new ThreadStart(MLauncher.Main.status.CheckStatus));
                MLauncher.Main.statusThread.Start();
                Application.Run(launcher);
            }

        }

        public static string CalculateMD5Hash(string input)
        { 
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

        public static void Serialize(Object o)
        {
            FileStream fs = new FileStream("mlchr.cfg", FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();
            try
            { formatter.Serialize(fs, o); }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to serialize. Reason: " + e.Message);
                throw;
            }
            finally
            { fs.Close(); }
        }

        public static Object Deserialize()
        {
            Object o = null;
            if (!File.Exists("mlchr.cfg"))
                return null;
            FileStream fs = new FileStream("mlchr.cfg", FileMode.Open);
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                o = (Object)formatter.Deserialize(fs);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to deserialize. Reason: " + e.Message);
                throw;
            }
            finally
            { fs.Close();}
            return o;
        }

        public static string Zakoduj(String kod, String txt)
        {
            char[] Ckod = kod.ToCharArray();
            int[] Ikod = new int[Ckod.Length];
            for (int i = 0; i < Ckod.Length; i++)
            {
                Ikod[i] = (int)Ckod[i];
            }
            char[] Ctxt = txt.ToCharArray();
            String wynik = "";
            int of = 0;
            foreach (char el in Ctxt)
            { 
                wynik += (char)(((int)el + Ikod[of]) - 77);
                of++;
                if (of > 6)
                {
                    of = 0;
                }
            }
            return wynik;
        }

        public static string Odkoduj(String kod, String txt)
        {

            char[] Ckod = kod.ToCharArray();
            int[] Ikod = new int[Ckod.Length];
            for (int i = 0; i < Ckod.Length; i++)
            {
                Ikod[i] = (int)Ckod[i];
            }
            char[] Ctxt = txt.ToCharArray();
            String wynik = "";
            int of = 0;
            foreach (char el in Ctxt)
            {
                wynik += (char)((((int)el + 77) - Ikod[of]));
                of++;
                if (of > 6)
                {
                    of = 0;
                }
            }
            return wynik;
        }

        public static bool CheckUpdates()
        {
            File.Delete("MUpdater.exe");
            var values = new NameValueCollection();
            values["version"] = MLauncher.Main.version;
            string odp = PostRequest("http://185.238.74.50/mlauncher/version.php", values);
            if(odp.Equals("Please update MLauncher!"))
            {
                return true;
            }
            return false;
        }

        public static void Update()
        {
            var client = new WebClient();
            client.DownloadFile("http://185.238.74.50/mlauncher/MUpdater.exe", "MUpdater.exe");
            System.Diagnostics.Process.Start("MUpdater.exe");
            return;
        }

        public static string PostRequest(string addr, NameValueCollection values)
        {
            var client = new WebClient();
            var response = client.UploadValues(addr, values);
            var responseString = Encoding.Default.GetString(response);
            return responseString;
        }
    }
}
