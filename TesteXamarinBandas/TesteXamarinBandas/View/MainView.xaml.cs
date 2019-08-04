using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TesteXamarinBandas.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainView : CarouselPage
    {
        public MainView()
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel();
        }

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem;
            App.AppNavigation.PushAsync(new DetailBand((Band)item));
        }

        void urlTapped(object sender, EventArgs args)
        {
            var labelSender = (Label)sender;

            Device.OpenUri(new Uri("http://" + labelSender.Text));
        }
    }
}