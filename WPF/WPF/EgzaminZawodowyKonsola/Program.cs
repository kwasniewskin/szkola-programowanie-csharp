using System;

namespace EgzaminZawodowyKonsola
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Liczba zarejestrowanych osób to {Osoba.liczbaInstancjiKlasy}");

            Osoba osoba1 = new Osoba();

            Console.WriteLine("Wprowadz id osoby: ");
            string id = Console.ReadLine();
            int.TryParse(id, out int intId);

            Console.WriteLine("Wprowadz imie osoby: ");
            string imie = Console.ReadLine();

            Osoba osoba2 = new Osoba(intId, imie);

            Osoba osoba3 = new Osoba(osoba2);

            osoba1.WypiszImie("Jan");
            osoba2.WypiszImie("Jan");
            osoba3.WypiszImie("Jan");

            Console.WriteLine($"Liczba zarejestrowanych osób to {Osoba.liczbaInstancjiKlasy}");
        }
    }
}
