﻿using System;
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
            if (!string.IsNullOrWhiteSpace(Imie))
                return true;

            Message = "Nie uzupelniono pola imie ";
            return false;
        }

        public bool Waliduj()
        {
            if (CzyUzupelnionoPole())
                return true;

            return false;
        }

    }
}
