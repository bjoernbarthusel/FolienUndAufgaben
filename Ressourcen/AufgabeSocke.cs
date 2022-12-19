using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AufgabeSocke
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Socke roteSocke = new Socke("rot", true, false);
            roteSocke.Ausführung();
        }
    }

    class Socke
    {

        public string farbe;
        public bool trocken;
        public bool sauber;

        public Socke(string farbe, bool trocken, bool sauber)
        {
            this.farbe = farbe;
            this.trocken = trocken;
            this.sauber = sauber;

        }

        public void Ausführung()
        {
            Ausgabe();

            Waschen();
            Ausgabe();
            
            Trocknen();
            Ausgabe();
            
            Benutzen();
            Ausgabe();

            Console.ReadLine();
        }

        public void Ausgabe()
        {
            string strTrocken;
            string strSauber;

            if (trocken) { strTrocken = "trocken"; } else { strTrocken = "nass"; } ;
            if (sauber) { strSauber = "sauber"; } else { strSauber = "schmutzig"; } ;
            Console.WriteLine("Die Socke mit der Farbe {0} ist {1} und {2}.", farbe, strTrocken, strSauber);
        }

        public void Waschen()
        {
            Console.WriteLine("Wasche...");
            sauber = true;
            trocken = false;
        }

        public void Trocknen()
        {
            Console.WriteLine("Trockne...");
            trocken = true;
        }

        public void Benutzen()
        {
            Console.WriteLine("Benutze...");
            sauber = false;
        }

    }



}
