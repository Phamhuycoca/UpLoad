﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Model
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string? ProductName { get; set; }
        public string? ProductImage { get; set; }

        [NotMapped]
        public IFormFile? ImageFile { get; set; }
    }
}
