
using System.Globalization;
using System.Windows.Controls;

namespace ViewModel.Validators;

/// <summary>
/// Класс валидатора положительных чисел.
/// </summary>
public class PositiveValueValidator : ValidationRule
{
    public override ValidationResult Validate(object value, CultureInfo cultureInfo)
    {
        string enteredValue = ((String)value).Replace('.', ',');

        try
        {
            if (Double.Parse(enteredValue) < 0)
                return new ValidationResult(false, "Value must be positive");
        }
        catch (FormatException exception)
        {
            return new ValidationResult(false, "Incorrect value format.");
        }

        return new ValidationResult(true, String.Empty);
    }
}
