using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcOOPHamburgerProject.Data.Context;
using MvcOOPHamburgerProject.Data.Entities.Concrete;
using MvcOOPHamburgerProject.Models;

namespace MvcOOPHamburgerProject.ViewComponents
{
    public class OurMenuViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _db;
        private readonly OurMenuViewModel _viewModel;

        public OurMenuViewComponent(ApplicationDbContext db, OurMenuViewModel viewModel)
        {
            _db = db;
            _viewModel = viewModel;
        }

        public async Task<IViewComponentResult> InvokeAsync(int? categoryId)
        {

            if (categoryId != null)
            {
                _viewModel.Products = await _db.Products.Where(p => p.CategoryId == categoryId).ToListAsync();
                _viewModel.Menus = null;
            }
            else
            {
                _viewModel.Menus = await _db.Menus.ToListAsync();
                _viewModel.Products = null;
            }

            _viewModel.Categories = await _db.Categories.ToListAsync();
            _viewModel.SelectedCategoryId = categoryId;

            return View(_viewModel);
        }
    }
}
