using System;
using System.Text.RegularExpressions;

namespace Banknotenprüfer
{
    public static class Seriennummerprüfer
    {
        public static string CheckSerial(string serialNumber)
        {
            try
            {
                // Auf Formatfehler prüfen
                CheckFormat(serialNumber.ToUpper().Trim());
            }
            catch (FormatException fe)
            {
                // Seriennummer mit Fehlertext zurückliefern
                return string.Format("{0} {1}", serialNumber, fe.Message);
            }

            string digitOnlyNumber = CreateDigitOnlySerial(serialNumber);

            // Seriennummer mit Generation und Gültigkeit zurückliefern
            return string.Format("{0} {1} {2}", serialNumber,
                                                IsSecondGeneration(serialNumber) ? "2. Gen" : "1. Gen",
                                                DigitalRoot(digitOnlyNumber) ? "Valide" : "Nicht Valide");
        }

        private static void CheckFormat(string serialNumber)
        {
            // Überprüfung der Länge
            if (serialNumber.Length < 12)
            {
                throw new FormatException("Zu Kurz");
            }
            else if (serialNumber.Length > 12)
            {
                throw new FormatException("Zu Lang");
            }

            // Welche Generation
            if (IsSecondGeneration(serialNumber))
            {
                // 2. Generation

                // Zwei Buchstaben zu Beginn?
                if (char.IsLetter(serialNumber[0]) == false &&
                    char.IsLetter(serialNumber[1]) == false)
                {
                    throw new FormatException("Kein Buchstabe");
                }

                // Gültiger Buchstabe zu Beginn?
                Regex validLetters = new Regex(@"^[DEHJMNPR-Z]");

                if (validLetters.IsMatch(serialNumber) == false)
                {
                    throw new FormatException("Falscher Buchstabe");
                }

                // Restliche Stellen nur Zahlen?
                Regex ziffernRegex = new Regex(@"^..\d{10}$");

                if (!ziffernRegex.IsMatch(serialNumber))
                {
                    throw new FormatException("Falsche Zeichen");
                }
            }
            else
            {
                // 1. Generation

                // Buchstabe am Anfang
                if (!char.IsLetter(serialNumber[0]))
                {
                    throw new FormatException("Kein Buchstabe");
                }

                // Gültiger Buchstabe zu Beginn?
                Regex validLetters = new Regex(@"^[^A-CI-KRW]");

                if (validLetters.IsMatch(serialNumber) == false)
                {
                    throw new FormatException("Falscher Buchstabe");
                }

                // Restliche Stellen nur Zahlen?
                Regex ziffernRegex = new Regex(@"^.\d{11}$");

                if (!ziffernRegex.IsMatch(serialNumber))
                {
                    throw new FormatException("Falsche Zeichen");
                }
            }
        }

        private static string CreateDigitOnlySerial(string original)
        {
            // In Großbuchstaben umwandeln
            original = original.ToUpper();
            string digitOnlySerial;
            if (IsSecondGeneration(original))
            {
                // 1. und 2. Stelle in ASCII Code umwandeln und des Rest des Strings an neuen String anfügen
                digitOnlySerial = ((int)original[0]).ToString() + ((int)original[1]).ToString() + original.Substring(2, original.Length - 2);
            }
            else
            {
                // 1. Stelle in ASCII Code umwandeln und des Rest des Strings an neuen String anfügen
                digitOnlySerial = ((int)original[0]).ToString() + original.Substring(1, original.Length - 1);
            }
            return digitOnlySerial;
        }

        private static bool DigitalRoot(string digitOnlySerialnumber)
        {
            int startQuersumme = 0;
            // Alle Ziffern aufaddieren
            for (int i = 0; i < digitOnlySerialnumber.Length; i++)
            {
                startQuersumme += int.Parse(digitOnlySerialnumber[i].ToString());
            }

            int zahl = startQuersumme;
            int neunerrest = 0;
            do
            {
                neunerrest = 0;
                // Quersumme bilden
                while (zahl > 0)
                {
                    neunerrest += zahl % 10;
                    zahl /= 10;
                }
                zahl = neunerrest;
            }
            while (neunerrest > 9); // Wiederholen falls Quersumme immernoch größer 9 ist

            return neunerrest == 9;
        }

        private static bool IsSecondGeneration(string serialnumber)
        {
            // Sind die ersten zwei Zeichen in der Seriennummer Buchstaben?
            bool twoLetters = char.IsLetter(serialnumber[0]) && char.IsLetter(serialnumber[1]);
            bool restDigits = true;

            // Überprüfen ob der Rest des Strings Ziffern sind
            for (int i = 2; i < serialnumber.Length; i++)
            {
                if (char.IsDigit(serialnumber[i]) == false)
                {
                    restDigits = false;
                }
            }
            return twoLetters && restDigits;
        }
    }
}