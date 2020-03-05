using System;
using System.Collections.ObjectModel;

namespace Basta2020Feb.CoffeeShop.ViewModels.Common
{
	internal class ObservableReadOnlyList<T> : ObservableCollection<T>, IObservableReadOnlyList<T>
	{
	}
}
