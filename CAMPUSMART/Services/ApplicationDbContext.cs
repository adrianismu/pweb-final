using CAMPUSMART.Models; // Importing the Product model
using Microsoft.EntityFrameworkCore; // Importing Entity Framework Core namespace

namespace CAMPUSMART.Services
{
    // DbContext represents the session with the database
    public class ApplicationDbContext : DbContext
    {
        // Constructor receiving DbContextOptions for database configuration
        public ApplicationDbContext(DbContextOptions options) : base(options) 
        { 
            // This constructor is used for configuring the database connection
        }

        // DbSet is a collection of entities (in this case, Products)
        public DbSet<Product> Products { get; set; }
        // This DbSet allows interaction with the Product entities in the database
    }
}
