using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MvcBookApplication.Models
{
    public class Author
    {
        [Key]
        public int AuthorID { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
