using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;

namespace Basta2020Feb.CoffeeShop.ViewModels.Common
{
	internal interface IObservableReadOnlyList<T> : IReadOnlyList<T>, INotifyCollectionChanged, INotifyPropertyChanged
	{
	}
}
