using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalidacjaImieWiek
{
    class WalidacjaImienia : IWalidacjaPola
    {
        public string Message { get; set; }
        public string Imie { get; set; }

        public WalidacjaImienia(string imie)
        {
            Message = "";
            this.Imie = imie;
        }
        
        public bool CzyUzupelnionoPole()
        {
            if (string.IsNullOrWhiteSpace(Imie))
                return false;

            return true;
        }

        public bool CzyWalidacjaPrzebieglaPoprawnie()
        {
            if (CzyUzupelnionoPole())
                return true;

            Message = "Nie podano imienia ";
            return false;
        }

    }
}
