using System.ComponentModel.DataAnnotations;

namespace Order66exe.Areas.Identity.Validation
{
    public class UniqueUsernameAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            return base.IsValid(value, validationContext);
        }
    }
}
