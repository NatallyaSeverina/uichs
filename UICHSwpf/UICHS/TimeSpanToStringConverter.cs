using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UICHS
{
    class TimeSpanToStringConverter : System.Windows.Data.IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int v = 0;
            if (value==null|| String.IsNullOrEmpty(value.ToString())) v = 0;
            else v = 1;
            if (v == 0)
                return string.Empty;
            return value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string s = (string)value;
            if (string.IsNullOrEmpty(s))
                return null;
            return s;
        }


    }
}
