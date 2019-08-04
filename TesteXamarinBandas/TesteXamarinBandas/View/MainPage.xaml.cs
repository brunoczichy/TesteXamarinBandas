﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteXamarinBandas.View;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TesteXamarinBandas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			//InitializeComponent();
            BindingContext = new MainPageViewModel();
		}

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem;
            App.AppNavigation.PushAsync(new DetailBand((Band)item));
        }

    }
}
