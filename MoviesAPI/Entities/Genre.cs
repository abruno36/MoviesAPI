using MoviesAPI.Validations;
using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Entities
{
    public class Genre
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The field with name {0} is required")]
        [StringLength(50, ErrorMessage = "The field with name {0} is maximum lenght of 50 catacteres")]
        [FirstLetterUppercase]
        public string Name { get; set; }

    }
}
