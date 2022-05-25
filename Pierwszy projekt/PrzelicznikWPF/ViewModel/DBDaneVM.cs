using PrzelicznikWPF.Model.BazaDanych.Model;
using PrzelicznikWPF.Model.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilitisWPF;

namespace PrzelicznikWPF.ViewModel
{
    class DBDaneVM : ObserverVM
    {
        private DBDane dane;

        private List<Rodzaj> _listaRodzaj;
        public List<Rodzaj> ListaRodzaj {
            get
            {
                return _listaRodzaj;
            }
            set
            {
                _listaRodzaj = value;
                OnPropertyChanged();
            }
        }

        private Rodzaj _wybranyRodzaj;
        public Rodzaj WybranyRodzaj {
            get
            {
                return _wybranyRodzaj;
            }
            set
            {
                _wybranyRodzaj = value;
                OnPropertyChanged();
            }
        }

        public DBDaneVM()
        {
            dane = new DBDane();
            ListaRodzaj = dane.GetRodzaje();

            //if (WybranyRodzaj == null)
            //    WybranyRodzaj = ListaRodzaj.First();
        }
    }
}
