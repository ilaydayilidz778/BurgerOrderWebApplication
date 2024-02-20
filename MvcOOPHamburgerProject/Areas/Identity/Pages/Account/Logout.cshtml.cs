// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MvcOOPHamburgerProject.Data.Context;
using MvcOOPHamburgerProject.Data.Entities.Concrete;
using MvcOOPHamburgerProject.Data.Entities.Enums;

namespace MvcOOPHamburgerProject.Areas.Identity.Pages.Account
{
    public class LogoutModel : PageModel
    {
        private readonly SignInManager<User> _signInManager;
        private readonly ILogger<LogoutModel> _logger;
        private readonly ApplicationDbContext _context;

        public LogoutModel(SignInManager<User> signInManager, ILogger<LogoutModel> logger, ApplicationDbContext context)
        {
            _signInManager = signInManager;
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> OnPost(string returnUrl = null)
        {
            await _signInManager.SignOutAsync();
            HttpContext.Session.Clear();
            _logger.LogInformation("User logged out.");

            // Kullanıcı siparişini sil 
            if (User.Identity.IsAuthenticated)
            {
                var user = await _signInManager.UserManager.GetUserAsync(User);

                // Siparişleri getir ve sadece ready veya delivery olanları seç
                var ordersToRemove = _context.Orders
                    .Where(o => o.UserId == user.Id && !(o.Status == OrderStatus.Ready || o.Status == OrderStatus.Delivered));

                // Seçilen siparişleri sil
                _context.Orders.RemoveRange(ordersToRemove);

                // Değişiklikleri veritabanına kaydet
                await _context.SaveChangesAsync();
            }

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
