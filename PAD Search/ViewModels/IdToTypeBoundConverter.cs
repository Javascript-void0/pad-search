using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace PAD_Search.ViewModels
{
    public class IdToTypeBoundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return new Rectangle(0, 0, 1, 1);
            var x = 0;
            var y = (int)value;
            if (y == 12 || y == 9) x = 1;
            return new Rectangle(x, y / 15.0, 2, 16);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
