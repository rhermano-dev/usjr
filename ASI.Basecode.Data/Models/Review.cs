using System.ComponentModel.DataAnnotations;

namespace MvcBookApplication.Models
{
    public class Review
    {
        public int ReviewNum { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        [Range(1, 5)]
        public int Rating { get; set; }

        public string ReviewName { get; set; }

        [Required]
        [EmailAddress]
        public string ReviewEmail { get; set; }

        public virtual Book Book { get; set; }
    }
}

