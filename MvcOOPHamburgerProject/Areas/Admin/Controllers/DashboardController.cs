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
        private readonly ApplicationDbContext _db;
        private readonly DashboardViewModel _dashboardViewModel;

        public DashboardController(ApplicationDbContext db, DashboardViewModel dashboardViewModel)
        {
            _db = db;
            _dashboardViewModel = dashboardViewModel;
        }

        public IActionResult Index()
        {
          return View();
        }
    }

}













