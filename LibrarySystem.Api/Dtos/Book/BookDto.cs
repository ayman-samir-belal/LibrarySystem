﻿using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Api.Dtos.Book
{
    public class BookDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public string Description { get; set; }
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero")]
        public decimal Price { get; set; }

        public string Author { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Stock must be greater than zero")]
        public int Stock { get; set; }
        public string CategoryName { get; set; }

    }
}
