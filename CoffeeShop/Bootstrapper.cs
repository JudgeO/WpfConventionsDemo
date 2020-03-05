using System;
using System.Windows;
using Basta2020Feb.CoffeeShop.ViewModels;
using Basta2020Feb.CoffeeShop.Views;

namespace Basta2020Feb.CoffeeShop
{
	internal class Bootstrapper
	{
		public Bootstrapper()
		{
			Application.Current.Startup += OnStartup;
		}

		private static void OnStartup(object sender, StartupEventArgs e)
		{
			var view = new MainView
			{
				DataContext = new MainViewModel()
			};

			view.Show();
		}
	}
}
