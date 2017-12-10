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
    public partial class MainView : ContentPage
    {
        public MainView()
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel(this);
        }

        public void LoadGrid(List<Band> bands)
        {
            int row = 0; int column = 0;

            foreach (var item in bands)
            {
                CardBand cardBand = new CardBand();
                cardBand.BindingContext = item;
                cardBand.ImageBand.Source = item.Image;
                cardBand.Name.Text = item.Name;
                TapGestureRecognizer tap = new TapGestureRecognizer(tapped);
                cardBand.GestureRecognizers.Add(tap);
                GridBands.Children.Add(cardBand, column, row);
                if (column == 1)
                {
                    column = 0;
                    row++;
                }
                else
                {
                    column++;
                }
            }
        }

        private void tapped(Xamarin.Forms.View arg1, object arg2)
        {
            App.AppNavigation.PushAsync(new DetailBand((Band) arg1.BindingContext));
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