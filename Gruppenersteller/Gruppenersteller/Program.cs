using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gruppenersteller
{
    class Program
    {

        static string[] löschen(string[] personen, int zufall, int anzahl)
        {
            return personen;
        }

        static string Ausgabe(string[,] gruppen)
        {
            string ausgabe = "";
            return ausgabe;
        }

        static void Main(string[] args)
        {
            string eingabe;
            short gruppenanzahl;
            Console.WriteLine("Es wird versucht die Datei name.txt einzulesen...");
            string[] personen = Datei.Laden(@".\namen.txt").Split('\n');
            if (personen[0] != "")
            {
                int anzahl = personen.Length;

                do
                {
                    Console.WriteLine("Wie viele Gruppen?");
                    eingabe = Console.ReadLine();
                } while (!Int16.TryParse(eingabe, out gruppenanzahl));

                Int32 mitgliederanzahl = anzahl / gruppenanzahl;
                string[,] gruppen = new string[gruppenanzahl, mitgliederanzahl];
                Random random = new Random();
                int i = 0, k = 0;
                while (anzahl > 0)
                {
                    if (i > gruppenanzahl - 1)
                    {
                        i = 0;
                        k++;
                    }

                    else
                    {
                        int zufall = random.Next(-1, anzahl + 1);
                        gruppen[i, k] = personen[zufall];
                        personen = löschen(personen, zufall, anzahl);
                        anzahl--;
                        i++;
                    }
                }

                string ausgabe = Ausgabe(gruppen);
                Datei.Schreiben(ausgabe);
                Console.WriteLine(ausgabe);
                Console.WriteLine("Eine beliebige Taste zum beenden drücken!");
                Console.ReadKey(true);
            }
            else
            {
                Console.WriteLine("Fehler! Programm wird beendet!");
                Console.WriteLine("Eine beliebige Taste zum beenden drücken!");
                Console.ReadKey(true);
            }
        }
    }
}
