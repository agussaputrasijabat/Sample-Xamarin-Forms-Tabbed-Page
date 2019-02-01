using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Web;
using Xamarin.Forms;

namespace XamarinGram.Helpers
{
    public class HtmlToText
    {
        public static string Convert(string HTML)
        {
            Regex reg = new Regex("<[^>]+>", RegexOptions.IgnoreCase);
            var stripped = reg.Replace(HTML, "");
            return HttpUtility.HtmlDecode(stripped);
        }
    }

    public class HtmlToTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return HtmlToText.Convert((string)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return HtmlToText.Convert((string)value);
        }
    }
}
