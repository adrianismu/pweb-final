// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using CAMPUSMART.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace CAMPUSMART.Areas.Identity.Pages.Account
{
    // LogoutModel represents the Razor Page for user logout.
    [AllowAnonymous] // Allows unauthenticated access to this page.
    public class LogoutModel : PageModel
    {
        private readonly SignInManager<CAMPUSMARTUser> _signInManager; // Manages user sign-in and sign-out.
        private readonly ILogger<LogoutModel> _logger; // Logger for logging user logout events.

        // Constructor for LogoutModel, injecting dependencies.
        public LogoutModel(SignInManager<CAMPUSMARTUser> signInManager, ILogger<LogoutModel> logger)
        {
            _signInManager = signInManager;
            _logger = logger;
        }

        // Handles the HTTP POST request for user logout.
        public async Task<IActionResult> OnPost(string returnUrl = null)
        {
            // Sign out the user.
            await _signInManager.SignOutAsync();

            // Log information about the user logout.
            _logger.LogInformation("User logged out.");

            // If a return URL is provided, redirect to that URL.
            if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                // This needs to be a redirect so that the browser performs a new
                // request and the identity for the user gets updated.
                return RedirectToPage();
            }
        }
    }
}
