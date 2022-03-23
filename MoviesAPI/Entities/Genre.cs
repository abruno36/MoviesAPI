using MoviesAPI.Validations;
using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Entities
{
    public class Genre: IValidatableObject
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The field with name {0} is required")]
        [StringLength(10, ErrorMessage = "The field with name {0} is maximum lenght of 10 catacteres")]
        [FirstLetterUppercase]
        public string Name { get; set; }

        //[Range(18, 120, ErrorMessage = "The age is invalid")]
        //public int Age { get; set; }

        //[CreditCard(ErrorMessage = "The Credicart is invalid")]
        //public string CreditCard { get; set; }

        //[Url]
        //public string Url { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!string.IsNullOrEmpty(Name))
            {
                var firstLetter = Name[0].ToString();

                if (firstLetter != firstLetter.ToUpper())
                {
                    yield return new ValidationResult("First letter should be uppercase - 1", new string[] { nameof(Name) });
                }
            }
        }
    }
}
