using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteXamarinBandas.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TesteXamarinBandas.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetailBand : ContentPage
	{
        // View de DetailBand
		public DetailBand (Band band)
		{
			InitializeComponent ();
            BindingContext = new DetailBandViewModel(band);
		}
	}
}