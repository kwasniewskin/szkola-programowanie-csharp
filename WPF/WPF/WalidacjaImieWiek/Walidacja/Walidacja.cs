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

        public Walidacja(List<IWalidacja> listaWalidacjiOtrzymana)
        {
            listaWalidacji = listaWalidacjiOtrzymana;
        }
        public Walidacja() { }

        public void DodanieNowejWalidacji(IWalidacjaPola walidacja)
        {
            listaWalidacji.Add(walidacja);
        }

        public bool CzyWalidacjaPrzebieglaPoprawnie()
        {
            if (!listaWalidacji.Any(walidacja => walidacja.CzyWalidacjaPrzebieglaPoprawnie() == false)){
                return true;
            } else
            {
                foreach (IWalidacja walidacja in listaWalidacji)
                {
                    Message += walidacja.Message;
                }

                return false;
            }

        }
            
    }
}
