using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MLauncher
{
    class RegistryCDK
    {
        static public bool AddCDK(string cdk, string path)
        {
            try
            {
                RegistryKey key = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32);
                key = key.OpenSubKey("SOFTWARE", true);
                key = key.CreateSubKey("IGI 2 Retail");
                RegistryKey cdkKey = key.CreateSubKey("CDKey");
                cdkKey.SetValue("CDKey", cdk);
                key = key.CreateSubKey("Installdir");
                key.SetValue("Installdir", path);
            }
            catch (Exception)
            {
                return false;
            }
           
            return true;
        }

        static public bool RemoveCDK()
        {
            try
            {
                RegistryKey key = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32);
                key = key.OpenSubKey("SOFTWARE", true);
                key.DeleteSubKeyTree("IGI 2 Retail");
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        static public bool ExistCDK()
        {
            RegistryKey key = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32);
            key = key.OpenSubKey("SOFTWARE");
            key = key.OpenSubKey("IGI 2 Retail");
            if(key == null)
            {
                return false;
            }
            return true;
        }

        static public string GetCDK()
        {
            if (!ExistCDK())
            {
                return "";
            }
            RegistryKey key = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32);
            key = key.OpenSubKey("SOFTWARE");
            key = key.OpenSubKey("IGI 2 Retail");
            key = key.OpenSubKey("CDKey");
            return (string) key.GetValue("CDKey");
            
        }

        static public bool ChangeCDK(string cdk)
        {
            try
            {
                RegistryKey key = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32);
                key = key.OpenSubKey("SOFTWARE",true);
                key = key.OpenSubKey("IGI 2 Retail",true);
                key = key.OpenSubKey("CDKey", true);
                key.SetValue("CDKey", cdk);

            }
            catch (Exception)
            {
                return false;
            }
          
            return true;
        }

        static public bool ChangePath(string path)
        {
            try
            {
                RegistryKey key = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32);
                key = key.OpenSubKey("SOFTWARE", true);
                key = key.OpenSubKey("IGI 2 Retail", true);
                key = key.OpenSubKey("Installdir", true);
                key.SetValue("Installdir", path);

            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        static public bool Equals(string cdk)
        {
            try
            {
                RegistryKey key = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32);
                key = key.OpenSubKey("SOFTWARE", true);
                key = key.OpenSubKey("IGI 2 Retail", true);
                key = key.OpenSubKey("CDKey", true);
                string regcdk = CalculateMD5Hash((string) key.GetValue("CDKey"));
                if (regcdk.Equals(cdk))
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception)
            {
                return false;
            }

            
        }

        public static string CalculateMD5Hash(string input)

        {

            // step 1, calculate MD5 hash from input

            MD5 md5 = System.Security.Cryptography.MD5.Create();

            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);

            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)

            {

                sb.Append(hash[i].ToString("X2"));

            }

            return sb.ToString();

        }
    }
}
