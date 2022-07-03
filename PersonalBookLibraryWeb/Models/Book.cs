using System.ComponentModel.DataAnnotations;

namespace PersonalBookLibraryWeb.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Field is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Maximum length of the field is 50 symbols and minimum length is 3")]
        public string? BookName { get; set; }

        [Required(ErrorMessage = "Field is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Maximum length of the field is 50 symbols and minimum length is 3")]
        public string? AuthorName { get; set; }

        [Required(ErrorMessage = "Field is required")]
        [Range(1, 5, ErrorMessage = "Minimum grade is 1 and maximum is 5")]
        public int Rating { get; set; }

        [StringLength(150, ErrorMessage = "Maximum length of the field is 150 symbols")]
        public string? ShortDescription { get; set; }

        [Required(ErrorMessage = "Field is required")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Maximum length of the field is 50 symbols and minimum length is 1")]
        public string? Section { get; set; }
    }
}
