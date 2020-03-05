using System;
using Basta2020Feb.CoffeeShop.ViewModels.Common;

namespace Basta2020Feb.CoffeeShop.ViewModels
{
	internal interface IMachineViewModel : IBaseViewModel
	{
		IObservableReadOnlyList<ICoffeeViewModel> Coffees { get; }

		string DisplayName { get; }
	}
}
