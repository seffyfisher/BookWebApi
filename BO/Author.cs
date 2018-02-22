using System.ComponentModel.DataAnnotations;

namespace BO
{
    public class AuthorModel
    {

        [Required,MaxLength(20),MinLength(3)]
        public string Name { get; set; }

        [Required,Range(18,120,ErrorMessage ="Age is not between 18 - 120")]
        public int? Age { get; set; }

        [Required,MinLength(5)]
        public string Image { get; set; }
    }
}
