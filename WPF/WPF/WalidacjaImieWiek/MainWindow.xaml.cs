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

        private void WyswietlanieBledow(string blad)
        {
            CzyPoprawneDane.Text = blad;
            CzyPoprawneDane.Foreground = Brushes.Red;
        }

        private void WyswietlanieBledowBindowanie(string blad)
        {
            CzyPoprawne = blad;
            Color = Brushes.Red;
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

        private void WyswietlanieDanych(string imie, string wiek)
        {
            CzyPoprawneDane.Text = $"Witaj! {imie}";

            CzyPelnoletni.Text = CzyPelnoletniMethod(wiek) ? "Pelnoletni" : "Niepelnoletni";
        }

        private void WyswietlanieDanychBindowanie(string imie, string wiek)
        {
            CzyPoprawne = $"Witaj! {imie}";

            CzyLetni = CzyPelnoletniMethod(wiek) ? "Pelnoletni" : "Niepelnoletni";
        }

        private void CzyszczenieTextBlockow()
        {
            CzyPoprawneDane.Text = "";
            CzyPelnoletni.Text = "";
        }

        private void CzyszczenieTextBlockowBindowanie()
        {
            CzyPoprawne = "";
            CzyLetni = "";
        }

        private void Sprawdz_Click(object sender, RoutedEventArgs e)
        {
            CzyszczenieTextBlockow();
            CzyPoprawneDane.Foreground = Brushes.Black;

            string imie = TextBoxImie.Text;
            string wiek = TextBoxWiek.Text;

            if (Walidacja.Waliduj(imie, wiek, out string message))
                WyswietlanieDanych(imie, wiek);
            else
                WyswietlanieBledow(message);
        }

        private void WywolajMetode(object parametr)
        {
            CzyszczenieTextBlockowBindowanie();
            Color = Brushes.Black;

            if (Walidacja.Waliduj(Imie, Wiek, out string message))
                WyswietlanieDanychBindowanie(Imie, Wiek);
            else
                WyswietlanieBledowBindowanie(message);
        }
    }
}
