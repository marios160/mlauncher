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
        public void CheckStatus()
        { 
            string[] status = GetStatus();
            int players = 0;
            if (status.Length > 16)
            {
                players = Int32.Parse(status[16]);
            }
            Console.WriteLine("Sprawdzanie");

            do
            {

                    status = GetStatus();
                    M.launcher.SetStatusInvoke(status);
                    if (status.Length > 16)
                    {
                        var p = Int32.Parse(status[16]);
                        if (p > players)
                        {
                            players = p;
                            MessageBox.Show("New player on server!", "New player!");

                        }
                        else
                        {
                            players = p;
                        }
                    }
                
                Thread.Sleep(3000);

            }
            while (M.dane.Notify);

        }

        public static string[] GetStatus()
        {
            var values = new NameValueCollection();
            values["email"] = M.dane.Email;
            values["word"] = M.dane.Pass;
            string odp = M.PostRequest("http://185.238.74.50/mlauncher/getStatus.php", values);
            return odp.Split('\\');
        }

    }
}
