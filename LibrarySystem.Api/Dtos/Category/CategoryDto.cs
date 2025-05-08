using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Api.Dtos.Category
{
    public class CategoryDto
    {
        [Required(ErrorMessage = "Name can not be empty")]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Description can not be empty")]
        public string Description { get; set; }
    }
}
