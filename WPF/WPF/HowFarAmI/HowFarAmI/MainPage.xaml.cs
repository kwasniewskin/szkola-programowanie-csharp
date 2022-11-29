using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.Threading;

namespace HowFarAmI
{
    public partial class MainPage : ContentPage
    {
        Location internat = new Location(50.87740188301604, 20.641851424109422);
        Location buskoZdroj = new Location(50.471198952937655, 20.720953716692463);

        private string result;
        public string Result
        {
            get { return result; }
            set { result = value; OnPropertyChanged(); }
        }

        public MainPage()
        {
            InitializeComponent();
            Task.Run(GetCurrentLocation);
        }

        async Task GetCurrentLocation()
        {
            while (true)
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));
                var location = await Geolocation.GetLocationAsync(request);

                if (location != null)
                {
                    double distance = Location.CalculateDistance(buskoZdroj, location, DistanceUnits.Kilometers);
                    Result = $"Odleglosc od Buska: {Math.Round(distance, 2)} km";
                }
                await Task.Delay(TimeSpan.FromSeconds(1));
            }
        }
    }
}
