using System;
using System.Globalization;
using Windows.UI.Xaml.Data;

namespace Expenses.ViewModels.Helpers
{
	public class DecimalToStringConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			if (value == null)
				return "0.00";

			int? digits = parameter as int?;

			if (digits == null)
				digits = 2;

			NumberFormatInfo nfi = (NumberFormatInfo)CultureInfo.InvariantCulture.NumberFormat.Clone();
			nfi.NumberGroupSeparator = " ";
			nfi.CurrencyDecimalSeparator = ".";
			nfi.NumberDecimalDigits = (int)digits;

			return ((decimal)value).ToString("n", nfi);
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			if (value == null)
				return 0.00m;

			decimal d;

			return decimal.TryParse((string)value, out d) ? d : 0.00m;
		}


	}
}