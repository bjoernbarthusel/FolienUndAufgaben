using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Boxer boxer1 = new Boxer("Kalle", 12);
            Boxer boxer2 = new Boxer("Ede", 8);

            boxer1.Gegner = boxer2;
            boxer2.Gegner = boxer1;

            boxer1.Schlag();

            Console.ReadLine();

        }
    }
}
