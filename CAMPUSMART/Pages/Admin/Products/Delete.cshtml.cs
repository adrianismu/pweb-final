using CAMPUSMART.Models;
using CAMPUSMART.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CAMPUSMART.Pages.Admin.Products
{
    public class DeleteModel : PageModel
    {
        private readonly IWebHostEnvironment environment;  // Interface to access web hosting environment
        private readonly ApplicationDbContext context;     // Database context for CRUD operations

        [BindProperty]
        public ProductDto ProductDto { get; set; } = new ProductDto();  // Bound property for form data

        public Product Product { get; set; } = new Product();  // Property to represent the product

        // Fields for error and success messages
        public string errorMessage = "";
        public string successMessage = "";

        // Constructor to inject services
        public DeleteModel(IWebHostEnvironment environment, ApplicationDbContext context)
        {
            this.environment = environment;
            this.context = context;
        }

        public void OnGet(Guid? id)
        {
            // Handling HTTP GET requests

            // Checking if ID is null and redirecting to product index if so
            if (id == null)
            {
                Response.Redirect("/Admin/Products/Index");
                return;
            }

            // Finding the product by ID
            var product = context.Products.Find(id);

            // Redirecting to product index if product not found
            if (product == null)
            {
                Response.Redirect("/Admin/Products/Index");
                return;
            }

            // Deleting the product image from server's storage
            string imageFullPath = environment.WebRootPath + "/products/" + product.ImageFileName;
            System.IO.File.Delete(imageFullPath);

            // Removing the product from database and saving changes
            context.Products.Remove(product);
            context.SaveChanges();

            // Redirecting to product index after successful deletion
            Response.Redirect("/Admin/Products/Index");
        }
    }
}
