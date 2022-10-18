using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DataBinding
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            const float accel = 0.1f;

            float speed = accel;
        
            InitializeComponent();
            
            Task.Run(() =>
            {
                while (true)
                {
                    RotateSlider.Value = (RotateSlider.Value + speed) % 360;
                    speed += accel;
                    Thread.Sleep(TimeSpan.FromSeconds(0.1));
                }
            });
        }
    }
}
