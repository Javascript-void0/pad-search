using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace PAD_Search.ViewModels
{
    public class AwokenIdConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //return new Rectangle(0,0,3,142);
            var x = 0;
            var y = (int)parameter;
            if (y == 40 || y == 46 || y == 47 || y == 48 || y == 109) x = 1;

            return new Rectangle(x / 2.0, y / 141.0, 3, 142);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
