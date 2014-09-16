using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gruppenersteller
{
    class Datei
    {
        static class Datei
        {
            /// <summary>
            /// Lädt eine Datei.
            /// </summary>
            /// <param name="datei">Der relative Pfad der Datei.</param>
            /// <returns>Gibt den Dateiinhalt als String zurück.</returns>
            static public string Laden(string datei)
            {
                StreamReader text = new StreamReader(datei, System.Text.Encoding.UTF8);
                string Text = text.ReadToEnd();
                text.Close();
                return Text;
            }

            /// <summary>
            /// Schreibt eine Textdatei.
            /// </summary>
            /// <param name="datei">Inhalt der Datei</param>
            /// <returns>Der Erfolg der Methode</returns>
            static public bool Schreiben(string datei)
            {
                try
                {
                    StreamWriter a = new StreamWriter(@".\Liste.txt");
                    a.Write(datei);
                    a.Close();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}
