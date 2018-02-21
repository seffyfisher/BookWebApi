using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace BO
{
    public class BookModel
    {
        public int? Id { get; set; }
        [MinLength(2),MaxLength(15)]
        public string BookName { get; set; }

        [Range(20,1500,ErrorMessage ="Number of pages must be between 20-1500")]
        public int NumOfPages { get; set; }
        
        [Range(30,200,ErrorMessage ="Price must be between 30-200")]
        public decimal Price { get; set; }

        public AuthorModel Author { get; set; }

    }
}
