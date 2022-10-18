using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalidacjaImieWiek
{
    class WalidacjaWieku
    {
        private string message;
        private string wiek;

        public WalidacjaWieku(string wiek)
        {
            message = "";
            this.wiek = wiek;
        }

        public bool CzyUzupelnionoPoleWiek()
        {
            if (string.IsNullOrWhiteSpace(wiek))
            {
                message = "Nie podano wieku ";
                return false;
            }

            return true;
        }

        public bool CzyLiczbaJestIntem()
        {
            if (int.TryParse(wiek, out int intWiek))
                return true;

            message = "Liczba nie jest intem";
            return false;
        }

        public bool CzyLiczbaJestWZakresie(int min, int max)
        {
            int.TryParse(wiek, out int intWiek);

            if (intWiek > min && intWiek < max)
                return true;

            message = "Liczba nie jest w zakresie";
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
            if (CzyUzupelnionoPoleWiek() && CzyPoprawnieUzupelnionoPoleWiek())
                return true;

            return false;
        }

        public string GetMessage()
        {
            return message;
        }
    }
}
