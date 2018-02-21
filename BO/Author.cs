using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BO
{
    public class AuthorModel
    {
        public int? Id { get; set; }

        [MaxLength(20),MinLength(3)]
        public string Name { get; set; }

        [Range(18,120,ErrorMessage ="Age is not between 18 - 120")]
        public int Age { get; set; }

        [MinLength(5)]
        public string Image { get; set; }
    }
}
