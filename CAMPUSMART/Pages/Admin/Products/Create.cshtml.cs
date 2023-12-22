using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CAMPUSMART.Models;
using CAMPUSMART.Services;
using System;
using System.IO;

namespace CAMPUSMART.Pages.Admin.Products
{
    public class CreateModel : PageModel
    {
        private readonly IWebHostEnvironment environment;  // Interface to access web hosting environment
        private readonly ApplicationDbContext context;       // Database context for CRUD operations

        [BindProperty]
        public ProductDto ProductDto { get; set; } = new ProductDto();  // Bound property for form data
        
        // Constructor to inject services
        public CreateModel(IWebHostEnvironment environment, ApplicationDbContext context) 
        {
            this.environment = environment;
            this.context = context;
        }

        public void OnGet()
        {
            // Logic for HTTP GET requests (initial load)
        }

        // Fields for error and success messages
        public string errorMessage = "";
        public string successMessage = "";

        public void OnPost() 
        {
            // Validation and data handling for HTTP POST requests (form submission)
            
            // Checking if the image file is provided
            if (ProductDto.ImageFile == null || ProductDto.ImageFile.FileName == null)
            {
                ModelState.AddModelError("ProductDto.ImageFile", "The image file is required");
            }
            
            // Checking if model state is valid
            if (!ModelState.IsValid)
            {
                errorMessage = "Please provide all the required fields";
                return;
            }

            // Save the image file to the server
            string newFileName = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            newFileName += Path.GetExtension(ProductDto.ImageFile!.FileName);

            string imageFullPath = Path.Combine(environment.WebRootPath, "products", newFileName);
            using (var stream = System.IO.File.Create(imageFullPath))
            {
                ProductDto.ImageFile.CopyTo(stream);
            }

            // Creating a new Product object and populating its properties
            Product product = new Product()
            {
                Name = ProductDto.Name,
                Brand = ProductDto.Brand,
                Category = ProductDto.Category,
                Price = ProductDto.Price,
                Description = ProductDto.Description ?? "", 
                ImageFileName = newFileName,
                CreatedAt = DateTime.Now,
            };

            // Adding the product to the database and saving changes
            context.Products.Add(product);
            context.SaveChanges();

            // Resetting form fields and clearing model state
            ProductDto.Name = "";
            ProductDto.Brand = "";
            ProductDto.Category = "";
            ProductDto.Price = 0;
            ProductDto.Description = "";
            ProductDto.ImageFile = null;
            ModelState.Clear();

            successMessage = "Product created Successfully";

            // Redirecting to the product index page
            Response.Redirect("/Admin/Products/Index");
        }
    }
}
