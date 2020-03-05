using System;
using Basta2020Feb.CoffeeShop.ViewModels.Common;

namespace Basta2020Feb.CoffeeShop.ViewModels
{
	internal interface IMainViewModel : IBaseViewModel
	{
		IObservableReadOnlyList<IAlertViewModel> Alerts { get; }

		IObservableReadOnlyList<IMachineViewModel> Machines { get; }

		IMachineViewModel SelectedMachine { get; set; }
	}
}
