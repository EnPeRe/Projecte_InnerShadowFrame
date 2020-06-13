using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Projecte_InnerShadowFrame
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShadowButton : ContentView
    {
        public ShadowButton()
        {
            InitializeComponent();
        }

        private async void Button_Pressed(object sender, EventArgs e)
        {
            await Task.Run(async () => await Task.Delay(100));
            ButtonElement.BackgroundColor = Color.FromHex("#333EBD");
        }

        private async void ButtonElement_Released(object sender, EventArgs e)
        {
            await Task.Run(async () => await Task.Delay(100));
            ButtonElement.BackgroundColor = Color.Transparent;
        }
    }
}