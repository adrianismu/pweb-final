using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;

namespace CAMPUSMART.Pages
{
    // Specifies that this page should not be cached and doesn't require an anti-forgery token
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    [IgnoreAntiforgeryToken]
    public class ErrorModel : PageModel
    {
        // Holds the request ID for error identification
        public string? RequestId { get; set; }

        // Determines if the request ID is available to display
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        private readonly ILogger<ErrorModel> _logger;

        // Constructor to inject the logger
        public ErrorModel(ILogger<ErrorModel> logger)
        {
            _logger = logger;
        }

        // Handles GET requests to this page
        public void OnGet()
        {
            // Sets the RequestId using Activity.Current or generates a new identifier
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
        }
    }
}
