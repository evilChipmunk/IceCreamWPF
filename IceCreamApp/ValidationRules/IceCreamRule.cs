 
using System.Globalization; 
using System.Windows.Controls;

namespace IceCreamApp.ValidationRules
{
    public class IceCreamRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string valueToValidate = value as string;
            if (valueToValidate.Length <= 0 || valueToValidate.Length > 20)
            {
                return new ValidationResult(false, "Name should be between 0 and 20 characters");
            }

            return new ValidationResult(true, null);
        }
    }
}
