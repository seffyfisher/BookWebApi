using System.ComponentModel.DataAnnotations;


namespace BO
{
    public class BookModel
    {
        [Required,MinLength(2),MaxLength(15)]
        public string BookName { get; set; }

        [Required,Range(20,1500,ErrorMessage ="Number of pages must be between 20-1500")]
        public int? NumOfPages { get; set; }
        
        [Required,Range(30,200,ErrorMessage ="Price must be between 30-200")]
        public decimal Price { get; set; }

        [Required]
        public AuthorModel Author { get; set; }

    }
}
