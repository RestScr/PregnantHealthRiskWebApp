

using System.Globalization;
using System.Windows.Data;
using Model.Enums;

namespace ViewModel.Converters;

public class HealthRiskToColorConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        switch ((HealthRisk)value)
        {
            case HealthRisk.Low:
                return "#009900";
            case HealthRisk.Medium:
                return "#008899";
            case HealthRisk.High:
                return "#880000";
            default:
                return "#000000";
        }
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        switch ((string)value)
        {
            case "#009900":
                return HealthRisk.Low;
            case "#008899":
                return HealthRisk.Medium;
            case "#880000":
                return HealthRisk.High;
            default:
                return HealthRisk.Unknown;
        }
    }
}
