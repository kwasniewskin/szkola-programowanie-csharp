using PrzelicznikWPF.Model.BazaDanych.Model;
using PrzelicznikWPF.Model.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
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
                UzupelnianieComboBoxJednostkaZ();
                UzupelnianieComboBoxJednostkaD();
            }
        }

        private List<Jednostki> _listaJednostka;  
        public List<Jednostki> ListaJednostka
        {
            get
            {
                return _listaJednostka;
            }
            set
            { 
                _listaJednostka = value;
                OnPropertyChanged();
            }
        }

        private Jednostki _wybranaJednostkaZ;
        public Jednostki WybranaJednostkaZ
        {
            get
            { 
                return _wybranaJednostkaZ; 
            }
            set
            {
                _wybranaJednostkaZ = value;
                OnPropertyChanged();
            }
        }

        private Jednostki _wybranaJednostkaD;
        public Jednostki WybranaJednostkaD
        {
            get
            {
                return _wybranaJednostkaD;
            }
            set
            {
                _wybranaJednostkaD = value;
                OnPropertyChanged();
            }
        }

        private string _wprowadzonaDana;
        public string WprowadzonaDana
        {
            get 
            {
                return _wprowadzonaDana; 
            }
            set
            {
                _wprowadzonaDana = value;
                OnPropertyChanged();
            }
        }

        private string _wynik;
        public string Wynik
        {
            get 
            { 
                return _wynik;
            }
            set 
            { 
                _wynik = value;
                OnPropertyChanged();
            }
        }


        private ICommand _przelicz; 
        public ICommand Przelicz
        {
            get
            {
                if (_przelicz == null) 
                    _przelicz = new RelayCommand<object>(PrzeliczanieJednostek);

                return _przelicz;
            }

        }
        public DBDaneVM()
        {
            dane = new DBDane();
            UzupelnianieComboBoxow();
        }

        private void PrzeliczanieJednostek(object obj)
        {
            
            if(WybranaJednostkaZ != WybranaJednostkaD) 
            {
                if (double.TryParse(WprowadzonaDana, out double wprowadzonaWartoscDouble))
                {
                    double przelicznik = dane.GetPrzelicznik(WybranaJednostkaZ, WybranaJednostkaD).Wartosc;
                    string symbol = WybranaJednostkaD.Symbol;

                    wprowadzonaWartoscDouble = wprowadzonaWartoscDouble * przelicznik;
                    Wynik = wprowadzonaWartoscDouble + " " + symbol;
                }
                else
                {
                    Wynik = "Wprowadz liczbe!";
                }
            } 
            else
            {
                Wynik = "Wybrano dwie takie same jednostki";
            }
        }


        #region Uzupelnianie ComboBoxow

        private void UzupelnianieComboBoxow()
        {
            UzupelnianieComboBoxRodzaj();
            UzupelnianieComboBoxJednostkaZ();
            UzupelnianieComboBoxJednostkaD();
        }

        private void UzupelnianieComboBoxJednostkaZ()
        {
            ListaJednostka = dane.GetJednostki(WybranyRodzaj);

            if (WybranaJednostkaZ == null)
                WybranaJednostkaZ = ListaJednostka.FirstOrDefault();

        }

        private void UzupelnianieComboBoxJednostkaD()
        {
            ListaJednostka = dane.GetJednostki(WybranyRodzaj);

            if (WybranaJednostkaD == null)
                WybranaJednostkaD = ListaJednostka.FirstOrDefault();

        }

        private void UzupelnianieComboBoxRodzaj()
        {
            ListaRodzaj = dane.GetRodzaje();

            if (WybranyRodzaj == null)
                WybranyRodzaj = ListaRodzaj.FirstOrDefault();
        }

        #endregion

    }
}
