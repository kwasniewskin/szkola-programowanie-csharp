using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalidacjaImieWiek
{
    class WalidacjaImienia
    {
        private string message;
        private string imie;

        public WalidacjaImienia(string imie)
        {
            message = "";
            this.imie = imie;
        }
        
        public bool CzyUzupelnionoPoleImie()
        {
            if (string.IsNullOrWhiteSpace(imie))
                return false;

            return true;
        }

        public bool CzyWalidacjaPrzebieglaPoprawnie()
        {
            if (CzyUzupelnionoPoleImie())
                return true;

            message = "Nie podano imienia ";
            return false;
        }

        public string GetMessage()
        {
            return message;
        }

    }
}
