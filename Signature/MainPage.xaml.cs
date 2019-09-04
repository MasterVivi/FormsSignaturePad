using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace Signature
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var thickness = On<iOS>().SafeAreaInsets();
            if (Device.RuntimePlatform == Device.iOS)
            {
                if (thickness.Top > 1)
                {
                    this.SafeViewTop.IsVisible = true;
                    this.SafeViewTop.HeightRequest = thickness.Top;
                }

                if (thickness.Bottom > 1)
                {
                    this.SafeViewBottom.IsVisible = true;
                    this.SafeViewBottom.HeightRequest = thickness.Bottom;
                }
            }
        }

        private async void SaveButton_Clicked(object sender, EventArgs e)
        {
            var stream = await signature.GetImageStreamAsync(SignaturePad.Forms.SignatureImageFormat.Png);
            var jpeg = ImageSource.FromStream(() => stream);
            result.Source = jpeg;
        }
    }
}
