using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace CAMPUSMART.Models
{
    // Represents a Product entity in the database.
    public class Product
    {
        // Product Id property (primary key in the database).
        public int Id { get; set; }

        // Product Name property with a maximum length of 100 characters.
        [MaxLength(100)]
        public string Name { get; set; } = "";

        // Product Brand property with a maximum length of 100 characters.
        [MaxLength(100)]
        public string Brand { get; set; } = "";

        // Product Category property with a maximum length of 100 characters.
        [MaxLength(100)]
        public string Category { get; set; } = "";

        // Product Price property with precision of 16 digits and 2 decimal places.
        public decimal Price { get; set; }

        // Product Description property.
        public string Description { get; set; } = "";

        // Product ImageFileName property with a maximum length of 100 characters.
        [MaxLength(100)]
        public string ImageFileName { get; set; } = "";

        // Product CreatedAt property representing the date and time when the product was created.
        public DateTime CreatedAt { get; set; }
    }
}
