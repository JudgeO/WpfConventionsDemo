using System;
using System.Windows.Input;
using Basta2020Feb.CoffeeShop.ViewModels.Common;

namespace Basta2020Feb.CoffeeShop.ViewModels
{
	internal interface ICoffeeViewModel : IBaseViewModel
	{
		bool CanOrderCoffee { get; }

		string Description { get; }

		string DisplayName { get; }

		string ImageSource { get; }

		bool IsSoldOut { get; }

		DateTime? LastRefill { get; }

		ICommand OrderCoffeeCommand { get; }

		int StockCapacity { get; }

		int StockCount { get; }

		string StockText { get; }

		void OrderCoffee();

		void Refill(int quantity);
	}
}
