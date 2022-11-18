using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace FlashLightXamarin
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void TurnOnFlashlightAsync(object sender, EventArgs e)
        {
            await Flashlight.TurnOnAsync();
        }

        private async void TurnOffFlashlightAsync(object sender, EventArgs e)
        {
            await Flashlight.TurnOffAsync();
        }
    }
}
