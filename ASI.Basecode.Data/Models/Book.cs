using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MvcBookApplication.Models
{
    public class Book
    {
        [Key]
        public int BookNum { get; set; }

        [Required]
        public int AuthorID { get; set; }

        public string Title { get; set; }

        public string Genre { get; set; }

        public virtual Author Author { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
    }
}
