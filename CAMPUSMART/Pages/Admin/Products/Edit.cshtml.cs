using CAMPUSMART.Models;
using CAMPUSMART.Services;
using Microsoft.AspNetCore.Http; // Correct import for the HTTP namespace
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.IO;

namespace CAMPUSMART.Pages.Admin.Products
{
    public class EditModel : PageModel
    {
        private readonly IWebHostEnvironment environment;
        private readonly ApplicationDbContext context;

        [BindProperty]
        public ProductDto ProductDto { get; set; } = new ProductDto();

        public Product Product { get; set; } = new Product();

        public string errorMessage = "";
        public string successMessage = "";

        public EditModel(IWebHostEnvironment environment, ApplicationDbContext context)
        {
            this.environment = environment;
            this.context = context;
        }

        // Handles HTTP GET request
        public void OnGet(Guid? id)
        {
            if (id == null)
            {
                // Redirects to the product index if ID is null
                RedirectToPage("/Admin/Products/Index");
                return;
            }

            var product = context.Products.Find(id);
            if (product == null)
            {
                // Redirects to the product index if product is not found
                RedirectToPage("/Admin/Products/Index");
                return;
            }

            // Fills DTO properties with product data
            ProductDto.Name = product.Name;
            ProductDto.Brand = product.Brand;
            ProductDto.Category = product.Category;
            ProductDto.Price = product.Price;
            ProductDto.Description = product.Description;

            Product = product;
        }

        // Handles HTTP POST request
        public void OnPost(Guid? id)
        {
            if (id == null)
            {
                // Redirects to the product index if ID is null
                RedirectToPage("/Admin/Products/Index");
                return;
            }

            if (!ModelState.IsValid)
            {
                // Sets an error message if model state is invalid
                errorMessage = "Please provide all the required fields";
                return;
            }

            var product = context.Products.Find(id);
            if (product == null)
            {
                // Redirects to the product index if product is not found
                RedirectToPage("/Admin/Products/Index");
                return;
            }

            string newFileName = product.ImageFileName; // Default file name from the product

            if (ProductDto.ImageFile != null)
            {
                // Generates a new file name using current time
                newFileName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + Path.GetExtension(ProductDto.ImageFile.FileName);

                string imageFullPath = Path.Combine(environment.WebRootPath, "products", newFileName);
                using (var stream = System.IO.File.Create(imageFullPath))
                {
                    ProductDto.ImageFile.CopyTo(stream);
                }

                // Deletes the old image file
                string oldImageFullPath = Path.Combine(environment.WebRootPath, "products", product.ImageFileName);
                System.IO.File.Delete(oldImageFullPath);
            }

            // Updates product properties with received data
            product.Name = ProductDto.Name;
            product.Brand = ProductDto.Brand;
            product.Category = ProductDto.Category;
            product.Price = ProductDto.Price;
            product.Description = ProductDto.Description ?? "";
            product.ImageFileName = newFileName;
            product.CreatedAt = DateTime.Now;

            context.SaveChanges(); // Saves changes to the database

            Product = product;

            successMessage = "Success";

            RedirectToPage("/Admin/Products/Index"); // Redirects to the product index page
        }
    }
}
