using System;
using System.Collections.Generic;

namespace EgzaminZawodowyKonsola2
{
    class Program
    {
        public static int[] tablica = new int[51];

        static void Main(string[] args)
        {
            WypelnianieTablicy();

            Console.WriteLine("Wprowadz poszukiwana liczbe: ");
            string wprowadzonaLiczba = Console.ReadLine();
            int.TryParse(wprowadzonaLiczba,out int wprowadzonaLiczbaInt);
            
            foreach (int item in tablica)
            {
                Console.Write($"{item},");
            }

            Console.WriteLine();
            if (PrzeszukiwanieTablicy(wprowadzonaLiczbaInt) == tablica.Length)
                Console.WriteLine("Nie znaleziono wprowadzonej liczby w tablicy");
            else
                Console.WriteLine($"Index znalezionej liczby: {PrzeszukiwanieTablicy(wprowadzonaLiczbaInt)}");

            Console.ReadLine();
        }

        public static void WypelnianieTablicy()
        {
            for (int i = 0; i < 50; i++)
            {
                Random random = new Random();
                int liczba = random.Next(1, 100);

                tablica[i] = liczba;
            }
        }

        /********************************************************************
            Nazwa funkcji: PrzeszukiwanieTablicy
            Argumenty: szukanyElement, przechowuje wprowadzona przez uzytkownika
                                        szukana liczbe
            Typ zwracany: int, zwraca index znalezionej liczby w tablicy
            Informacje: Wyszukuje argument 'szykanyElement' w tablicy, nastepnie
                        zwraca index tablicy gdzie znaleziono liczbe
            Autor: Nikodem Kwaśniewski
        ********************************************************************/
        public static int PrzeszukiwanieTablicy(int szukanyElement)
        {
            tablica[50] = szukanyElement;
            int index = 0;

            foreach (int liczba in tablica)
            {
                index++;

                if(liczba == szukanyElement)
                {
                    if(index != tablica.Length)
                    {
                        return index;
                    }
                }
            }

            return index;
        }
    }
}
