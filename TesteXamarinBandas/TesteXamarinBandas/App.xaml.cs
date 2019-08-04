using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TesteXamarinBandas.View;
using Xamarin.Forms;

namespace TesteXamarinBandas
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

        	AppNavigation = new NavigationPage(new MainView());
            AppNavigation.BarBackgroundColor = Color.Navy;
            AppNavigation.BarTextColor = Color.Wheat;
            MainPage = AppNavigation;
		}

        public static NavigationPage AppNavigation
        {
            get;
            set;
        }

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
