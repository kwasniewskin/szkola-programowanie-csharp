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
        
        public bool CzyWalidacjaPrzebieglaPoprawnie()
        {
            if (string.IsNullOrEmpty(imie))
            {
                message = "Nie podano imienia ";
                return false;
            }

            return true;
        }

        public string GetMessage()
        {
            return message;
        }

    }
}
