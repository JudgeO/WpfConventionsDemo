using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace Basta2020Feb.CoffeeShop.Views.Converters
{
	internal class ValueInRangeConverter : MarkupExtension, IValueConverter
	{
		public int Min { get; set; }

		public int Max { get; set; }

		public object IfTrue { get; set; }

		public object IfFalse { get; set; }

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value is int x)
			{
				return x >= Min && x <= Max ? IfTrue : IfFalse;
			}

			return DependencyProperty.UnsetValue;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}

		public override object ProvideValue(IServiceProvider serviceProvider)
		{
			return this;
		}
	}
}
