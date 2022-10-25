using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalidacjaImieWiek
{
    class Walidacja : IWalidacja
    {
        private List<IWalidacja> listaWalidacji = new List<IWalidacja>();
        public string Message { get; set; }
        public bool CzyWalidacjaPrzebieglaPoprawnie { get; set; }

        public Walidacja() { }

        public Walidacja(List<IWalidacja> listaWalidacjiOtrzymana)
        {
            listaWalidacji = listaWalidacjiOtrzymana;
        }

        public void DodanieNowejWalidacji(IWalidacjaPola walidacja)
        {
            listaWalidacji.Add(walidacja);
        }

        public bool Waliduj()
        {
            if (!listaWalidacji.Any(walidacja => walidacja.Waliduj() == false))
            {
                CzyWalidacjaPrzebieglaPoprawnie = true;
                return true;
            }
            else
            {
                foreach (IWalidacja walidacja in listaWalidacji)
                {
                    Message += walidacja.Message;
                }

                CzyWalidacjaPrzebieglaPoprawnie = false;
                return false;
            }
        }
            
    }
}
