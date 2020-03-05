using System;
using System.Windows.Input;
using Basta2020Feb.CoffeeShop.ViewModels.Common;

namespace Basta2020Feb.CoffeeShop.ViewModels
{
	internal interface IAlertViewModel : IBaseViewModel
	{
		ICommand ConfirmCommand { get; }

		string Message { get; }

		event EventHandler AlertConfirmed;

		void Confirm();
	}
}
