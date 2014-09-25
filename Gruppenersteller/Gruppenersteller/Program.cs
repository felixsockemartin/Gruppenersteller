using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gruppenersteller
{
    class Program
    {
        static string[] personen;
        static short gruppenanzahl;
        static decimal mitgliederanzahl;


        static void Quicksort(IComparable[] elements, int left, int right)
        {
            int i = left, j = right;
            IComparable pivot = elements[(left + right) / 2];

            while (i <= j)
            {
                while (elements[i].CompareTo(pivot) < 0)
                {
                    i++;
                }

                while (elements[j].CompareTo(pivot) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    // Swap
                    IComparable tmp = elements[i];
                    elements[i] = elements[j];
                    elements[j] = tmp;

                    i++;
                    j--;
                }
            }

            // Recursive calls
            if (left < j)
            {
                Quicksort(elements, left, j);
            }

            if (i < right)
            {
                Quicksort(elements, i, right);
            }
        }
        

        static void löschen(int i, int k)
        {
            personen[i] = "zzzzzzzzzzzzzzz";
            Quicksort(personen, 0, k - 1);
            Array.Resize<string>(ref personen, k - 1);
        }

        static string Ausgabe(string[,] gruppen)
        {
            string ausgabe = "";
            for (int k = 0; k < gruppenanzahl; k++)
            {
                ausgabe += "Gruppe " + (k + 1) + ":\n";
                for (int i = 0; i < mitgliederanzahl; i++)
                {
                    ausgabe += gruppen[k, i] + "\n";
                }
            }
            return ausgabe;
        }

        static void Main(string[] args)
        {
            string eingabe;
            Console.WriteLine("Es wird versucht die Datei name.txt einzulesen...");
            personen = Datei.Laden(@".\namen.txt").Split('\n');
            if (personen[0] != "")
            {
                int anzahl = personen.Length;

                do
                {
                    Console.WriteLine("Wie viele Gruppen?");
                    eingabe = Console.ReadLine();
                } while (!Int16.TryParse(eingabe, out gruppenanzahl));
                mitgliederanzahl = Convert.ToDecimal(anzahl) / Convert.ToDecimal(gruppenanzahl);
                decimal runden = mitgliederanzahl;
                runden = Math.Round(runden);
                if (mitgliederanzahl > runden)
                {
                    runden++;
                    mitgliederanzahl = runden;
                }
                string[,] gruppen = new string[gruppenanzahl, Convert.ToInt32(mitgliederanzahl)];
                Random random = new Random();
                int i = 0, k = 0;
                Console.WriteLine("Gruppen werden erstellt...");
                while (anzahl > 0)
                {
                    if (i > gruppenanzahl - 1)
                    {
                        i = 0;
                        k++;
                    }

                    else
                    {
                        int zufall = random.Next(0, anzahl);
                        //if (k > mitgliederanzahl - 1)
                        //{ k--; }
                        gruppen[i, k] = personen[zufall];
                        löschen(zufall, anzahl);
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
