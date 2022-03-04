
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;


namespace MLauncherServer
{
    class Program
    {
        static public MySqlConnection conn;
        static void Main(string[] args)
        {

            Thread sniffer = new Thread(new ThreadStart(Sniffer.Start));
            sniffer.Start();
            OpenMysql();
            Dictionary<int, string> dict = new Dictionary<int, string>();
            do
            {
                MySqlDataReader rdr =  Query("SELECT id, ip FROM user WHERE status='2';");
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        dict.Add(rdr.GetInt32("id"), rdr.GetString("ip"));
                    }
                    rdr.Close();
                    foreach (var item in dict)
                    {
                        Shell("iptables","-A INPUT -s " + item.Value + " -p udp --dport 26001 --sport 26015 -j ACCEPT");
                        Console.WriteLine("Added new ip: " + item.Value);
                        Query_v("UPDATE user SET status='3' WHERE id='" + item.Key + "';");
                    }
                    dict.Clear();
                }
                if (!rdr.IsClosed)
                {
                    rdr.Close();
                }
                System.Threading.Thread.Sleep(2000);
            } while (true);
            CloseMysql();
        }

        static public void OpenMysql()
        {
            string connStr = "server=185.238.74.50;user=root;database=igi2;port=3306;password=XedeX160!";
            conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

            }            
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }

        static public void CloseMysql()
        {
            conn.Close();
        }

        static public MySqlDataReader Query(string sql)
        { 
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();      
            return rdr;
        }

        static public void Query_v(string sql)
        {
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            rdr.Close();

        }

        static public void Shell(string prog, string command)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo() { FileName = prog, Arguments = command, };
            Process proc = new Process() { StartInfo = startInfo, };
            proc.Start();
        }
        
    }
}
