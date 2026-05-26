
using System.Globalization;
using System.Windows.Data;
using Model.Enums;


namespace ViewModel.Converters;

public class HealthRiskToTextConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        switch ((HealthRisk)value)
        {
            case HealthRisk.Low:
                return "Низкий";
            case HealthRisk.Medium:
                return "Средний";
            case HealthRisk.High:
                return "Высокий";
            default:
                return "Неизвестен";
        }
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        switch ((string)value)
        {
            case "Низкий":
                return HealthRisk.Low;
            case "Средний":
                return HealthRisk.Medium;
            case "Высокий":
                return HealthRisk.High;
            default:
                return HealthRisk.Unknown;
        }
    }
}
