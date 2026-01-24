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
            //var x = 0;
            //var y = (int)parameter;
            //if (HasNAVersion(y)) x = 1;

            //return new Rectangle(x / 2.0, y / 141.0, 3, 142);
            return Convert2((int)parameter);
        }

        public static Rectangle Convert2(int id)
        {
            var x = 0;
            var y = (int)id;
            if (HasNAVersion(y)) x = 1;

            return new Rectangle(x / 2.0, y / 141.0, 3, 142);
        }

        public static bool HasNAVersion(int id)
        {
            return id == 40 || id == 46 || id == 47 || id == 48 || id == 109;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
