using System;
using System.Collections.Generic;
using Basta2020Feb.CoffeeShop.ViewModels.Common;

namespace Basta2020Feb.CoffeeShop.ViewModels
{
	internal class MachineViewModel : BaseViewModel, IMachineViewModel
	{
		private readonly ObservableReadOnlyList<ICoffeeViewModel> _coffees = new ObservableReadOnlyList<ICoffeeViewModel>();

		public IObservableReadOnlyList<ICoffeeViewModel> Coffees => _coffees;

		public string DisplayName { get; }

		public MachineViewModel(string name, IEnumerable<ICoffeeViewModel> coffees)
		{
			DisplayName = name;

			foreach (var coffee in coffees)
			{
				_coffees.Add(coffee);
			}
		}
	}
}
