using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalidacjaImieWiek
{
    class Walidacja
    {
        public static bool Waliduj(string imie, string wiek, out string message)
        {
            WalidacjaImienia walidacjaImienia = new WalidacjaImienia(imie);
            WalidacjaWieku walidacjaWieku = new WalidacjaWieku(wiek);

            message = "";

            if (walidacjaImienia.CzyWalidacjaPrzebieglaPoprawnie() && walidacjaWieku.CzyWalidacjaPrzebieglaPoprawnie())
                return true;

            message = walidacjaImienia.GetMessage() + walidacjaWieku.GetMessage();
            return false;
        }
            
    }
}
