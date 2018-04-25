using System;
using System.Globalization;
using System.Windows.Data;

namespace IceCreamApp.Converters
{
     
    public class MarginConverter : IValueConverter
    {
        public object Convert(object dimensionValue, Type targetType, object converterParameter, CultureInfo culture)
        { 

            //example usage -- Bind to a parent property, but make  (in this case) the Height 100 less than the parent
            //   Height="{Binding Path=TheActualHeight
            //, RelativeSource ={ RelativeSource Mode = FindAncestor, AncestorType = local:LogResultsView}
            //, Converter ={ StaticResource MarginConverter}, ConverterParameter = -100}"
            double result = 0;

      
            if (dimensionValue != null && converterParameter != null)
            {
                try
                {
                    double numerator = (double)dimensionValue;
                    double denominator = double.Parse(converterParameter.ToString());

                    return numerator + denominator;
                }
                catch (Exception e)
                {
                    int i = 0;
                }
            }

            return result;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}