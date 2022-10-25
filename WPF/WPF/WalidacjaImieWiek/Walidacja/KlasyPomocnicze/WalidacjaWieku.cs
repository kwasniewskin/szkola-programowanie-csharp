using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalidacjaImieWiek
{
    class WalidacjaWieku : IWalidacjaPola
    {
        public string Message { get; set; }
        public string Wiek { get; set; }

        public WalidacjaWieku(string wiek)
        {
            Message = "";
            this.Wiek = wiek;
        }

        public bool CzyUzupelnionoPole()
        {
            if (string.IsNullOrWhiteSpace(Wiek))
            {
                Message = "Nie uzupelniono pola wiek ";
                return false;
            }

            return true;
        }

        public bool CzyLiczbaJestIntem()
        {
            if (int.TryParse(Wiek, out int intWiek))
                return true;

            Message = "Wprowadzona dana nie jest liczba calkowita";
            return false;
        }

        public bool CzyLiczbaJestWZakresie(int min, int max)
        {
            int.TryParse(Wiek, out int intWiek);

            if (intWiek > min && intWiek < max)
                return true;

            Message = $"Liczba poza zakresem {min}-{max}";
            return false;
        }

        public bool CzyPoprawnieUzupelnionoPoleWiek()
        {
            if (CzyLiczbaJestIntem() && CzyLiczbaJestWZakresie(0,150))
                return true;

            return false;
        }

        public bool CzyWalidacjaPrzebieglaPoprawnie()
        {
            if (CzyUzupelnionoPole() && CzyPoprawnieUzupelnionoPoleWiek())
                return true;

            return false;
        }
    }
}
