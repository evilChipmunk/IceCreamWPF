using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using IceCreamApp.ViewModels;

namespace IceCreamApp.Converters
{
    public class ImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //  path = "Images/Vanilla.png";
            if (value == null) return null;

            string path = "Images/";
            if (value is IImageLink)
            {
                IImageLink viewModel = value as IImageLink;
                if (string.IsNullOrEmpty(viewModel.ImageLink))
                {
                    return null;
                } 
                    path += viewModel.ImageLink;
            }
            else if (value is string)
            {
                path += value;
            }
            else
            {
                return null;
            }
        
       
            var bitmap = new BitmapImage(new Uri("/IceCreamApp;component/" + path, UriKind.Relative));
            return bitmap;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    } 
}
