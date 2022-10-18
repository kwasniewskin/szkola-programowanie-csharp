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

        public bool CzyPoprawnieUzupelnionoPoleWiek()
        {
            if (int.TryParse(wiek, out int intWiek) && intWiek > 0 && intWiek < 150)
                return true;

            message = "Nie poprawnie uzupelniono pole wiek ";
            return false;
        }

        public bool CzyUzupelnionoPoleWiek()
        {
            if (string.IsNullOrEmpty(wiek))
            {
                message = "Nie podano wieku ";
                return false;
            }

            return true;
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
