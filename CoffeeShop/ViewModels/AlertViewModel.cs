using System;
using Basta2020Feb.CoffeeShop.ViewModels.Common;

namespace Basta2020Feb.CoffeeShop.ViewModels
{
	internal class AlertViewModel : BaseViewModel, IAlertViewModel
	{
		public string Message { get; }

		public event EventHandler AlertConfirmed;

		public AlertViewModel(string message)
		{
			Message = message;
		}

		public void Confirm()
		{
			AlertConfirmed?.Invoke(this, EventArgs.Empty);
		}
	}
}
