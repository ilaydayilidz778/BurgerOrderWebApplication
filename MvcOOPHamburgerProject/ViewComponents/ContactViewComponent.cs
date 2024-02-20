using Microsoft.AspNetCore.Mvc;
using MvcOOPHamburgerProject.Data.Context;

namespace MvcOOPHamburgerProject.ViewComponents
{
    public class ContactViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _db;

        public ContactViewComponent(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
