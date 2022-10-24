using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using UtilitisWPF;

namespace WalidacjaImieWiek
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        private Brush _color;
        public Brush Color
        {
            get { return _color; }
            set
            {
                _color = value;
                OnPropertyChanged();
            }
        }

        private string _imie;
        public string Imie
        {
            get { return _imie; }
            set
            {
                _imie = value;
                OnPropertyChanged();
            }
        }

        private string _wiek;
        public string Wiek
        {
            get { return _wiek; }
            set
            {
                _wiek = value;
                OnPropertyChanged();
            }
        }

        private string _czyPoprawne;
        public string CzyPoprawne
        {
            get { return _czyPoprawne; }
            set
            {
                _czyPoprawne = value;
                OnPropertyChanged();
            }
        }

        private string _czyLetni;
        public string CzyLetni
        {
            get { return _czyLetni; }
            set
            {
                _czyLetni = value;
                OnPropertyChanged();
            }
        }

        private ICommand _sprawdzButtonCommand;
        public ICommand SprawdzButtonCommand
        {
            get
            {

                if (_sprawdzButtonCommand == null)
                    _sprawdzButtonCommand = new RelayCommand<object>(WywolajMetode);

                return _sprawdzButtonCommand;
            }
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void CzyszczenieTextBlockow()
        {
            TextBlockPoprawnoscDanych.Text = "";
            TextBlockPelnoletnosc.Text = "";
        }

        private void CzyszczenieTextBlockowBindowanie()
        {
            CzyPoprawne = "";
            CzyLetni = "";
        }


        private bool CzyPelnoletniMethod(string wiek)
        {
            int.TryParse(wiek, out int intWiek);

            if (intWiek > 18)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        private void WyswietlanieBledow(string blad)
        {
            TextBlockPoprawnoscDanych.Text = blad;
            TextBlockPoprawnoscDanych.Foreground = Brushes.Red;
        }

        private void WyswietlanieBledowBindowanie(string blad)

        {
            CzyPoprawne = blad;
            Color = Brushes.Red;
        }

        private void WyswietlanieDanych(string imie, string wiek)
        {
            TextBlockPoprawnoscDanych.Text = $"Witaj! {imie}";

            TextBlockPelnoletnosc.Text = CzyPelnoletniMethod(wiek) ? "Pelnoletni" : "Niepelnoletni";
        }

        private void WyswietlanieDanychBindowanie(string imie, string wiek)
        {
            CzyPoprawne = $"Witaj! {imie}";

            CzyLetni = CzyPelnoletniMethod(wiek) ? "Pelnoletni" : "Niepelnoletni";
        }

        private void Sprawdz_Click(object sender, RoutedEventArgs e)
        {
            CzyszczenieTextBlockow();
            TextBlockPoprawnoscDanych.Foreground = Brushes.Black;

            string imie = TextBoxImie.Text;
            string wiek = TextBoxWiek.Text;

            Walidacja walidacja = new Walidacja();
            walidacja.DodanieNowejWalidacji(new WalidacjaImienia(imie));
            walidacja.DodanieNowejWalidacji(new WalidacjaWieku(wiek));

            if (walidacja.CzyWalidacjaPrzebieglaPoprawnie())
                WyswietlanieDanych(imie, wiek);
            else
                WyswietlanieBledow(walidacja.Message);
        }

        private void WywolajMetode(object parametr)
        {
            
            CzyszczenieTextBlockowBindowanie();
            Color = Brushes.Black;

            Walidacja walidacja = new Walidacja();
            walidacja.DodanieNowejWalidacji(new WalidacjaImienia(Imie));
            walidacja.DodanieNowejWalidacji(new WalidacjaWieku(Wiek));

            if (walidacja.CzyWalidacjaPrzebieglaPoprawnie())                                                           
                WyswietlanieDanychBindowanie(Imie, Wiek);
            else
                WyswietlanieBledowBindowanie(walidacja.Message);
            
        }
    }
}
