using System;
using Basta2020Feb.CoffeeShop.ViewModels.Common;

namespace Basta2020Feb.CoffeeShop.ViewModels
{
	internal interface IAlertViewModel : IBaseViewModel
	{
		string Message { get; }

		event EventHandler AlertConfirmed;

		void Confirm();
	}
}
