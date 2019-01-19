using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistryApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Podaj CDKey:");
            string cdk = Console.ReadLine();
            if (RegistryCDK.checkCDK())
            {
                Console.WriteLine("Klucz jest już stworzony!");
                Console.WriteLine("Zmieniam CDK...");
                RegistryCDK.changeCDK(cdk);
            }
            else
            {
                Console.WriteLine("Tworze nowy klucz...");
                RegistryCDK.addCDK(cdk, "C:\\Program Files (x86)\\Codemasters\\Project IGI2");
            }

            Console.WriteLine("Nowy klucz CDKey został utworzony!");
            Console.WriteLine("Aby zakończyć wczyśnij przycisk...");
            Console.ReadKey();
        }
    }
}
