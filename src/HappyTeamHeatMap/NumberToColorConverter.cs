using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace HappyTeamHeatMap
{
    [ValueConversion(typeof(double), typeof(Brush))]
    public class NumberToColorConverter: IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var doubleValue = (double)value;

            Color color = new Color();
            color.B = 0;
            color.R = (byte)Math.Floor(255 * (1.0 - doubleValue));
            color.G = (byte)Math.Floor(255 * doubleValue);
            color.A = 255;

            return new SolidColorBrush(color);
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
