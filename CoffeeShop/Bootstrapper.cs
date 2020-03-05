using System;
using System.Windows;
using Caliburn.Micro;
using Basta2020Feb.CoffeeShop.ViewModels;
using Basta2020Feb.CoffeeShop.Views;

namespace Basta2020Feb.CoffeeShop
{
	internal class Bootstrapper : BootstrapperBase
	{
		public Bootstrapper()
		{
			Initialize();
		}

		protected override void OnStartup(object sender, StartupEventArgs e)
		{
			DisplayRootViewFor<MainViewModel>();
		}
	}
}
