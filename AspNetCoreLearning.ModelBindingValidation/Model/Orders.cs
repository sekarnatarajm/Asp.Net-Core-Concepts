using AspNetCoreLearning.ModelBindingValidation.Common;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreLearning.ModelBindingValidation.Model
{
    public class Orders : IValidatableObject
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [FutureDate(ErrorMessage = "date validation failed")]
        public DateTime OrderDate { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!string.IsNullOrWhiteSpace(Email) && EmailValidation.EmailDomainValidate(Email, ["dell", "dellteam"]))
            {
                yield return new ValidationResult("Email domain validate failed.",
                                new[] { nameof(Email) });
            }
        }
    }
}
