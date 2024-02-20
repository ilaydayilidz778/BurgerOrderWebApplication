using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcOOPHamburgerProject.Data.Context;

namespace MvcOOPHamburgerProject.ViewComponents
{
    public class TestimonialViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _db;

        public TestimonialViewComponent(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _db.Testimonials.ToListAsync());
        }
    }
}
