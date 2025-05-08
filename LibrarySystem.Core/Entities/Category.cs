using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Core.Entities
{
    public class Category
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name can not be empty")]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Description can not be empty")]
        public string Description { get; set; }

        public ICollection<Book> Books { get; set; } = new HashSet<Book>();
    }
}
