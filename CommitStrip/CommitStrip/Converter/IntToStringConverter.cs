using System;
using System.Globalization;
using MvvmCross.Platform.Converters;

namespace CommitStrip.Core.Converter
{
    public class IntToStringConverter : MvxValueConverter<int, string>
    {
        protected override string Convert(int value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.ToString();
        }

        protected override int ConvertBack(string value, Type targetType, object parameter, CultureInfo culture)
        {
            if (string.IsNullOrEmpty(value))
            {
                return 0;
            }
            return int.Parse(value);
        }
    }
}