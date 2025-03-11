using System.ComponentModel.DataAnnotations;

namespace CenterfieldAPI.Attributes
{
    public class ValidTimeFormatAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null) return false;

            // The time format expected is HH:mm
            if (value is TimeOnly time)
            {
                return true; // Return true if it's a valid TimeOnly value
            }
            return false; // Invalid if not in correct format
        }
    }

}
