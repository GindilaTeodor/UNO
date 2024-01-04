using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
// System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace Uno.Converters
{
    public class ColorConvertors : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            
           
                if (ColorConverter.ConvertFromString(value.ToString()) is Color convertedColor)
                {
                    return new SolidColorBrush(convertedColor);
                }
         
            return new SolidColorBrush(Colors.Transparent);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
