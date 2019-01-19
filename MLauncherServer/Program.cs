using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLauncherServer
{
    class Program
    {
        static public MySqlConnection conn;
        static void Main(string[] args)
        {
            openMysql();
            Dictionary<int, string> dict = new Dictionary<int, string>();
            do
            {
                MySqlDataReader rdr =  query("SELECT id, ip FROM user WHERE status='2';");
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        dict.Add(rdr.GetInt32("id"), rdr.GetString("ip"));
                    }
                    rdr.Close();
                    foreach (var item in dict)
                    {
                        shell("iptables","-A INPUT -s " + item.Value + " -j ACCEPT");
                        Console.WriteLine("Added new ip: " + item.Value);
                        query_v("UPDATE user SET status='3' WHERE id='" + item.Key + "';");
                    }
                    dict.Clear();
                }
                if (!rdr.IsClosed)
                {
                    rdr.Close();
                }
                System.Threading.Thread.Sleep(2000);
            } while (true);
            closeMysql();
        }

        static public void openMysql()
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

        static public void closeMysql()
        {
            conn.Close();
        }

        static public MySqlDataReader query(string sql)
        { 
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();      
            return rdr;
        }

        static public void query_v(string sql)
        {
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            rdr.Close();

        }

        static public void shell(string prog, string command)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo() { FileName = prog, Arguments = command, };
            Process proc = new Process() { StartInfo = startInfo, };
            proc.Start();
        }
        
    }
}
