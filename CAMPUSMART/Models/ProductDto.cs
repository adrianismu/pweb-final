using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CAMPUSMART.Models
{
    public class ProductDto
    {
        [Required, MaxLength(100)]
        public string Name { get; set; } = "";
        [Required, MaxLength(100)]
        public string Brand { get; set; } = "";
        [Required, MaxLength(100)]
        public string Category { get; set; } = "";
        [Required, Precision(16, 2)]
        public decimal Price { get; set; }
        public string? Description { get; set; } = "";
    
        public IFormFile? ImageFile { get; set; }
    }
}
