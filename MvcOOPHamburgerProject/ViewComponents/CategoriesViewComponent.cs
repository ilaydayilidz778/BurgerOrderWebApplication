using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcOOPHamburgerProject.Data.Context;

namespace MvcOOPHamburgerProject.ViewComponents
{
    public class CategoriesViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _db;

        public CategoriesViewComponent(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IViewComponentResult> InvokeAsync()  
        {
            return View(await _db.Categories.ToListAsync());
        }
    }
}
