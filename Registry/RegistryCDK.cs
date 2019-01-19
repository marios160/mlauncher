using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistryApp
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

        static public bool checkCDK()
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
    }
}
