using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ASI.Basecode.Services.ServiceModels
{
    public class BookViewModel
    {
        [JsonPropertyName("bookId")]
        [Required(ErrorMessage = "Book Id is required.")]
        public string bookId { get; set; }

        [JsonPropertyName("title")]
        [Required(ErrorMessage = "Book title is required.")]
        public string title { get; set; }

        [JsonPropertyName("description")]
        [Required(ErrorMessage = "Book description is required.")]
        public string description { get; set; }

        [JsonPropertyName("pubYear")]
        [Required(ErrorMessage = "Publishing year is required.")]
        public DateOnly pubYear { get; set; }
    }
}