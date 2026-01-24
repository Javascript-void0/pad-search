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

        private static List<int> DoubleAwakeningIds = new List<int>{ 56, 107, 111, 109, 96, 110, 108, 112, 113, 114, 97, 104, 98, 105, 73, 74, 75, 76, 77 };
        private static List<int> SingleAwakeningIds = new List<int>{ 21, 43, 61, 48, 27, 78, 60, 126, 59, 45, 50, 29, 9, 20, 73, 74, 75, 76, 77 };
        public static List<int> DecompressedAwakenings(List<int> awakenings)
        {
            List<int> decompressed = new List<int>();
            foreach (int awakening in awakenings)
            {
                if (DoubleAwakeningIds.Contains(awakening))
                {
                    int index = DoubleAwakeningIds.IndexOf(awakening);
                    decompressed.Add(SingleAwakeningIds[index]);
                    decompressed.Add(SingleAwakeningIds[index]);
                }
                else
                    decompressed.Add(awakening);
            }
            return decompressed;
        }

        public static bool ContainAwakenings(List<int> filter, List<int> awakenings)
        {
            foreach (int awakening in filter)
            {
                if (awakenings.Contains(awakening))
                {
                    awakenings.Remove(awakening);
                }
                else return false;
            }
            return true;

        }

    }
}
