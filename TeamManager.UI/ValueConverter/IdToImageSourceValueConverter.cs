using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamManager.UI.ValueConverter
{
    internal class IdToImageSourceValueConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            string localFilePath = "C:\\Users\\Zahar\\source\\repos\\TeamManager\\TeamManager.UI\\Images";
            localFilePath = System.IO.Path.Combine(localFilePath, $"{(int)value}.png");
            if (!File.Exists(localFilePath) )
            {
                return "blank_image.png";
            }
            return localFilePath;
        }
        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
