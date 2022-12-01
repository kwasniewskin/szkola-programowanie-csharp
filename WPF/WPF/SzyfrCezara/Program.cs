using System;

namespace SzyfrCezara
{
    class Program
    {
        static void Main(string[] args)
        {
            int przesuniecie;

            Console.WriteLine("Podaj wyraz do zaszyfrowania: ");
            string wyraz = Console.ReadLine();
            Console.WriteLine("Podaj przesuniecie:");
            string przesuniecieString = Console.ReadLine();
            int.TryParse(przesuniecieString, out przesuniecie);

            void Szyfrowanie()
            {
                char[] wyrazTab;

                for(int i = 0; 1 < wyraz.Length; i++)
                {
                    wyraz[i]

                }
            }

            void Deszyfrowanie()
            {

            }
        }
    }
}
