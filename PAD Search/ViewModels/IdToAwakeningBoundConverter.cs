using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace PAD_Search.ViewModels
{
    public class IdToAwakeningBoundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return new Rectangle(0, 0, 1, 1);
            var x = 0;
            var y = (int)value;
            if (AwokenIdConverter.HasNAVersion(y)) x = 1;
            return new Rectangle(x / 2.0, y / 141.0, 3, 142);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
