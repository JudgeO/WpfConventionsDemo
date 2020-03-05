using System;
using System.Windows.Input;
using Basta2020Feb.CoffeeShop.ViewModels.Common;

namespace Basta2020Feb.CoffeeShop.ViewModels
{
	internal class AlertViewModel : BaseViewModel, IAlertViewModel
	{
		private ICommand _confirmCommand;

		public ICommand ConfirmCommand => _confirmCommand ?? (_confirmCommand = new CommandHelper(Confirm, () => true));

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
