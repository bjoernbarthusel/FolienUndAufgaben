using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Socke roteSocke = new Socke();
            roteSocke.farbe = "rot";
            roteSocke.trocken = true;
            roteSocke.sauber = false;
            roteSocke.Ausgabe();
            
        }
    }

    class Socke
    {

        public string farbe;
        public bool trocken;
        public bool sauber;

        public void Ausgabe()
        {
            string strTrocken;
            if (trocken) { strTrocken = "trocken"; } else { strTrocken = "nass"; } ;
            string strSauber;
            if (sauber) { strSauber = "sauber"; } else { strSauber = "schmutzig"; } ;

            Console.WriteLine("Die Socke mit der Farbe {0} ist {1} und {2}.", farbe, strTrocken, strSauber);
            

        }

    }



}
