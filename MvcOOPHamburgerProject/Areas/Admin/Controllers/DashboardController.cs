using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcOOPHamburgerProject.Areas.Admin.Models;
using MvcOOPHamburgerProject.Data.Context;
using MvcOOPHamburgerProject.Data.Entities.Concrete;

namespace MvcOOPHamburgerProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly DashboardViewModel _dashboardViewModel;
        private readonly UserManager<User> _userManager;

        public DashboardController(ApplicationDbContext context, DashboardViewModel dashboardViewModel, UserManager<User> userManager)
        {
            _context = context;
            _dashboardViewModel = dashboardViewModel;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            // Toplam Müşteri Sayısı
            var users = await _userManager.GetUsersInRoleAsync("Customer");
            ViewBag.TotalAmountofCustomers = users.Count;

            // En Çok Sipariş Veren İlk 10 Müşteri
            var topCustomers = _context.Orders
             .GroupBy(o => o.UserId)
             .Select(g => new DashboardViewModel
             {
                 CustomerName = g.FirstOrDefault().User.UserName,
                 TotalOrdersAmount = g.Count()
             })
             .OrderByDescending(vm => vm.TotalOrdersAmount)
             .Take(10)
             .ToList();

            ViewBag.TopCustomers = topCustomers;


            // En çok sipariş edilen ürün
            var mostOrderedProduct = _context.OrderDetails
                .GroupBy(od => od.ProductId)
                .Select(g => new DashboardViewModel
                {
                    ProductName = _context.Products.FirstOrDefault()!.Name,
                    TotalOrdersOfProduct = g.Sum(od => od.Quantity)
                })
                .OrderByDescending(x => x.TotalOrdersOfProduct)
                .FirstOrDefault();

            ViewBag.MostOrderedProduct = mostOrderedProduct;

            // En çok sipariş edilen menü
            var mostOrderedMenu = _context.OrderDetails
                .GroupBy(od => od.MenuId)
                .Select(g => new DashboardViewModel
                {
                    MenuName = _context.Menus.FirstOrDefault()!.Name,
                    TotalOrdersOfMenu = g.Sum(od => od.Quantity)
                })
                .OrderByDescending(x => x.TotalOrdersOfMenu)
                .FirstOrDefault();

            ViewBag.MostOrderedMenu = mostOrderedMenu;

            // En çok sipariş verilen ilk 10 şehir


            // En çok sipariş edilen ürün kategorileri
            var mostOrderedCategories = _context.OrderDetails
              .Include(od => od.Product)
              .ThenInclude(p => p.Category)
              .GroupBy(od => od.Product.Category.Name)
              .Select(g => new
              {
                  CategoryName = g.Key,
                  TotalOrders = g.Sum(od => od.Quantity)
              })
              .OrderByDescending(x => x.TotalOrders)
              .Take(10)
              .ToList();
            ViewBag.MostOrderedCategories = mostOrderedCategories;

            // En son eklenen 10 ürün
            var recentlyAdded10Products = _context.Products.OrderByDescending(x => x.Id).Take(10).ToList();
            ViewBag.RecentlyAdded10Products = recentlyAdded10Products;

            // En son eklenen 10 menü
            var recentlyAdded10Menus = _context.Menus.OrderByDescending(x => x.Id).Take(10).ToList();
            ViewBag.RecentlyAdded10Menus = recentlyAdded10Menus;

            // En son eklenen 10 yorum
            var recentlyAdded10Testimonials = _context.Testimonials.OrderByDescending(x => x.Id).Take(10).ToList();
            ViewBag.RecentlyAdded10Testimonials = recentlyAdded10Testimonials;

            // Günlük Kazanç
            var dailyEarnings = _context.Orders
                .Where(o => o.Date.Date == DateTime.Today)
                .Sum(o => o.TotalPrice);
            ViewBag.DailyEarning = dailyEarnings;

            // Haftalık Kazanç
            var startOfWeek = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek);
            var weeklyEarnings = _context.Orders
                .Where(o => o.Date >= startOfWeek)
                .Sum(o => o.TotalPrice);
            ViewBag.WeeklyEarning = weeklyEarnings;

            // Aylık Kazanç
            var startOfMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            var monthlyEarnings = _context.Orders
                .Where(o => o.Date >= startOfMonth)
                .Sum(o => o.TotalPrice);
            ViewBag.MonthlyEarning = monthlyEarnings;



            return View();
        }
    }
}














