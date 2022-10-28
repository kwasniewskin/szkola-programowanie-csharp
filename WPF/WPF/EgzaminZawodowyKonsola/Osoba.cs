using System;
using System.Collections.Generic;
using System.Text;

namespace EgzaminZawodowyKonsola
{
    class Osoba
    {
        private int id;
        private string imie;
        public static int liczbaInstancjiKlasy = 0;

        public Osoba()
        {
            id = 0;
            imie = "";
            liczbaInstancjiKlasy++;
        }

        public Osoba(int id, string imie)
        {
            this.id = id;
            this.imie = imie;
            liczbaInstancjiKlasy++;
        }

        public Osoba(Osoba osoba)
        {
            id = osoba.id;
            imie = osoba.imie;
            liczbaInstancjiKlasy++;
        }

        public void WypiszImie(string imieWejsciowe)
        {
            if (imie != "")
                Console.WriteLine($"Cześć {imieWejsciowe}, mam na imię {imie}");
            else
                Console.WriteLine("Brak danych");
        }
    }
}
