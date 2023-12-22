using CAMPUSMART.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CAMPUSMART.Models;
using System.Collections.Generic;  // Import necessary namespace for List

namespace CAMPUSMART.Pages.Admin.Products
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext context;

        // Property to hold the list of products
        public List<Product> products { get; set; } = new List<Product>();

        // Constructor to inject the database context
        public IndexModel(ApplicationDbContext context)
        {
            this.context = context;
        }

        // Handler for HTTP GET requests
        public void OnGet()
        {
            // Retrieve and order products by ID in descending order
            products = context.Products.OrderByDescending(p => p.Id).ToList();
        }
    }
}
