using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Basta2020Feb.CoffeeShop.ViewModels.Common;

namespace Basta2020Feb.CoffeeShop.ViewModels
{
	internal class CoffeeViewModel : BaseViewModel, ICoffeeViewModel
	{
		private const int TimeToMarkAsNew = 10000;

		private readonly string _name;
		private ICommand _orderCoffeeCommand;

		public bool CanOrderCoffee => StockCount > 0;

		public string Description { get; }

		public string DisplayName { get; private set; }

		public string ImageSource { get; }

		public bool IsSoldOut => StockCount == 0;

		public DateTime? LastRefill { get; private set; }

		public ICommand OrderCoffeeCommand => _orderCoffeeCommand ?? (_orderCoffeeCommand = new CommandHelper(OrderCoffee, () => CanOrderCoffee));

		public int StockCapacity => 10;

		public int StockCount { get; private set; }

		private void OnStockCountChanged()
		{
			Application.Current.Dispatcher?.BeginInvoke((Action)CommandManager.InvalidateRequerySuggested);
		}

		public string StockText => $"{StockCount} / {StockCapacity}";

		public CoffeeViewModel(string name, int stockCount, string imageFileName, string description)
		{
			_name = name;
			DisplayName = name;
			Description = description;
			ImageSource = $"pack://application:,,,/CoffeeShop;component/Resources/{imageFileName}";
			StockCount = stockCount;
		}

		public void OrderCoffee()
			=> StockCount--;

		public void Refill(int quantity)
		{
			StockCount += quantity;
			LastRefill = DateTime.Now;
			Task.Run(TemporarilyChangeDisplayname);
		}

		private async void TemporarilyChangeDisplayname()
		{
			DisplayName = $"{_name} *";
			await Task.Delay(TimeToMarkAsNew)
				.ConfigureAwait(false);
			var lastRefill = LastRefill;
			if (lastRefill.HasValue && DateTime.Now.Subtract(lastRefill.Value).TotalMilliseconds >= TimeToMarkAsNew)
			{
				DisplayName = _name;
			}
		}
	}
}
