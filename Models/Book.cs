using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class Book
    {
        [Key]
        public int BookID { get; set; }
        [Required]
        [RegularExpression("^[0-9]{3}(?:-[0-9]{10})?$", ErrorMessage = "Invalid ISBN")]
        public string ISBN { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string AuthorFirstName { get; set; }
        public string AuthorMidName { get; set; }
        [Required]
        public string AuthorLastName { get; set; }
        [Required]
        public int NumPages { get; set; }
        [Required]
        public string Publisher { get; set; }
        [Required]
        public string Classification { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public double Price { get; set; }

    }
}
