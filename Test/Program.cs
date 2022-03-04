using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            String cdk = "";
            for (int i = 0; i < 4; i++)
            {
                cdk +=  new string(Enumerable.Repeat(chars, 4).Select(s => s[random.Next(s.Length)]).ToArray()) + '-' ;
            }
            cdk = cdk.Substring(0, 19);
            Console.WriteLine(cdk);
            Console.ReadKey();
        }
    }
}
