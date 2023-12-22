using CAMPUSMART.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CAMPUSMART.Data
{
    // CAMPUSMARTContext class represents the database context for the application.
    // It extends IdentityDbContext with the custom user class CAMPUSMARTUser.
    public class CAMPUSMARTContext : IdentityDbContext<CAMPUSMARTUser>
    {
        // Constructor for CAMPUSMARTContext that takes DbContextOptions as a parameter.
        public CAMPUSMARTContext(DbContextOptions<CAMPUSMARTContext> options)
            : base(options)
        {
        }

        // Override of OnModelCreating method to customize the ASP.NET Identity model.
        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Call the base OnModelCreating method to include default Identity model configurations.
            base.OnModelCreating(builder);

            // Customize the ASP.NET Identity model here if needed.
            // This is the place to make changes like renaming table names, adding customizations, etc.

            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
