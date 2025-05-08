using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Api.Dtos.Book
{
    public class AddBookDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public string Description { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "Price must be non-negative")]
        public decimal Price { get; set; }
        public string Author { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Stock must be non-negative")]
        public int Stock { get; set; }
        public int CategoryId { get; set; }
    }
}
