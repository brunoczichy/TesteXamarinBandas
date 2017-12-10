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
	public partial class CardBand : ContentView
	{
		public CardBand ()
		{
			InitializeComponent ();
		}

        public Image ImageBand
        {
            get { return Image; }
        }

        public Label Name
        {
            get { return BandName; }
        }

	}
}