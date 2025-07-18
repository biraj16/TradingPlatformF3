using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace TradingConsole.Wpf.Converters
{
    public class OiToWidthConverter : IMultiValueConverter
    {
        private const double MaxBarWidth = 120.0; // The maximum width of an OI bar in pixels

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length < 2 || !(values[0] is decimal currentOi) || !(values[1] is long maxOi))
            {
                return 0.0;
            }

            if (maxOi == 0)
            {
                return 0.0;
            }

            double width = ((double)currentOi / maxOi) * MaxBarWidth;
            return Math.Max(0, width); // Ensure width is not negative
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}