using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Basta2020Feb.CoffeeShop.Views.Converters
{
	internal class BooleanToValueConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var parameterString = parameter as string;
			if (parameterString == null)
			{
				return DependencyProperty.UnsetValue;
			}

			var parameters = parameterString.Split(';');
			if (parameters.Length != 2)
			{
				return DependencyProperty.UnsetValue;
			}

			if (value is bool b)
			{
				return b ? parameters[0] : parameters[1];
			}

			return DependencyProperty.UnsetValue;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
