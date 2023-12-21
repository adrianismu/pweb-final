using CAMPUSMART.Models;
using Microsoft.EntityFrameworkCore;

namespace CAMPUSMART.Services
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) 
        { 
        
        }

        public DbSet<Product> Products { get; set; }
    }
}
