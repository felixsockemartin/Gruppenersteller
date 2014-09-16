using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gruppenersteller
{
    class Program
    {
        static void Main(string[] args)
        {
            string eingabe;
            short gruppenanzahl;
            Console.WriteLine("Wie viele Gruppen?");
            do
            {
                eingabe = Console.ReadLine();
            } while (!Int16.TryParse(eingabe, out gruppenanzahl));
        }
    }
}
