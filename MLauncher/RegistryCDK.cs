using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLauncher
{
    class RegistryCDK
    {
        static public bool addCDK(string cdk, string path)
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

        static public bool removeCDK()
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

        static public bool existCDK()
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

        static public string getCDK()
        {
            if (!existCDK())
            {
                return "";
            }
            RegistryKey key = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32);
            key = key.OpenSubKey("SOFTWARE");
            key = key.OpenSubKey("IGI 2 Retail");
            key = key.OpenSubKey("CDKey");
            return (string) key.GetValue("CDKey");
            
        }

        static public bool changeCDK(string cdk)
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

        static public bool changePath(string path)
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

        static public bool equals(string cdk)
        {
            try
            {
                RegistryKey key = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32);
                key = key.OpenSubKey("SOFTWARE", true);
                key = key.OpenSubKey("IGI 2 Retail", true);
                key = key.OpenSubKey("CDKey", true);
                string regcdk = M.CalculateMD5Hash((string) key.GetValue("CDKey"));
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
    }
}
