using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalidacjaImieWiek
{
    interface IWalidacja
    {
        string Message { get; set; }

        bool CzyUzupelnionoPole();

        bool CzyWalidacjaPrzebieglaPoprawnie();

        string GetMessage();
    }
}
