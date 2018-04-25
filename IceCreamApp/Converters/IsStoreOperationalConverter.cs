using System;
using System.Globalization;
using System.Windows.Data;

namespace IceCreamApp.Converters
{
    public class IsStoreOperationalConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                var val = value.ToString();
                if (val != "Online")
                {
                    return false;
                }
            }
            return true;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new InvalidOperationException("IsNullConverter can only be used OneWay.");
        }
    }
}