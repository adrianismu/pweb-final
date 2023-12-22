using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CAMPUSMART.Models
{
    // Represents a Data Transfer Object (DTO) for Product information.
    public class ProductDto
    {
        // Product Name property with validation attributes.
        [Required, MaxLength(100)]
        public string Name { get; set; } = "";

        // Product Brand property with validation attributes.
        [Required, MaxLength(100)]
        public string Brand { get; set; } = "";

        // Product Category property with validation attributes.
        [Required, MaxLength(100)]
        public string Category { get; set; } = "";

        // Product Price property with validation attributes.
        [Required, Precision(16, 2)]
        public decimal Price { get; set; }

        // Product Description property.
        public string? Description { get; set; } = "";

        // Product ImageFile property representing an uploaded image file.
        public IFormFile? ImageFile { get; set; }
    }
}
