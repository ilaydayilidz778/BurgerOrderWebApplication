using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcOOPHamburgerProject.Areas.Admin.Models;
using MvcOOPHamburgerProject.Data.Context;
using MvcOOPHamburgerProject.Data.Entities.Concrete;

namespace MvcOOPHamburgerProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly NewCategoryViewModel _newCategoryViewModel;

        public CategoriesController(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // GET: Admin/Categories
        public async Task<IActionResult> Index()
        {
            return View(await _context.Categories.ToListAsync());
        }

        // GET: Admin/Categories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // GET: Admin/Categories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(NewCategoryViewModel newCategoryViewModel)
        {
            var category = new Category();
            if (ModelState.IsValid)
            {
                if (_context.Categories.FirstOrDefault(c => c.Name == newCategoryViewModel.Name) != null)
                {
                    ModelState.AddModelError("", "The category you want to enter already exist");
                }
                else
                {
                    category.Name = newCategoryViewModel.Name;
                    category.Description = newCategoryViewModel.Description;

                    string ext = Path.GetExtension(newCategoryViewModel.Image.FileName);
                    string newFileName = newCategoryViewModel.Name.Trim().Replace(" ", "") + ext;
                    category.ImageUrl = newFileName;
                    string fileStream = Path.Combine(_env.WebRootPath, "customer", "img", "category", newFileName);

                    RemoveImageFormFile(category);

                    // Dosya yolunu oluştur ve ekle ama bu dasya yolu varsa hata oluştur.
                    using (var fs = new FileStream(fileStream, FileMode.Create))
                    {
                        newCategoryViewModel.Image.CopyTo(fs);
                    }

                    _context.Add(category);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index), new { Result = "Added" });
                }
            }
            return View(newCategoryViewModel);
        }

        // GET: Admin/Categories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            var editCategoryViewModel = new EditCategoryViewModel()
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
                ImageUrl = category.ImageUrl,
            };
            return View(editCategoryViewModel);
        }

        // POST: Admin/Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditCategoryViewModel editCategoryViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Category category = await _context.Categories.FindAsync(id)!;

                    if (category == null)
                    {
                        return NotFound();
                    }
                    if (_context.Categories.FirstOrDefault(c => c.Name == editCategoryViewModel.Name && c.Id != editCategoryViewModel.Id) != null)
                    {
                        ModelState.AddModelError("", "The category you want to update already exist");
                    }
                    else
                    {
                        category.Name = editCategoryViewModel.Name;
                        category.Description = editCategoryViewModel.Description;

                        if (editCategoryViewModel.Image != null)
                        {
                            RemoveImageFormFile(category);

                            string ext = Path.GetExtension(editCategoryViewModel.Image.FileName);
                            string newFileName = editCategoryViewModel.Name.Trim().Replace(" ", "") + ext;
                            category.ImageUrl = newFileName;
                            string fileStream = Path.Combine(_env.WebRootPath, "customer", "img", "category", newFileName);

                            using (var fs = new FileStream(fileStream, FileMode.Create))
                            {
                                editCategoryViewModel.Image.CopyTo(fs);
                            }

                        }
                        _context.Update(category);
                        await _context.SaveChangesAsync();
                    }

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(editCategoryViewModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(editCategoryViewModel);
        }

        // GET: Admin/Categories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: Admin/Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, Category category)
        {
            category = await _context.Categories.FindAsync(id);
            if (category != null)
            {
                RemoveImageFormFile(category);
                _context.Categories.Remove(category);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { Result = "Deleted" });
        }

        private bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.Id == id);
        }

        public void RemoveImageFormFile(Category category)
        {
            if (category.ImageUrl != null)
            {
                string deletedImageFileName = category.ImageUrl;
                string deletedImageFilePath = Path.Combine(_env.WebRootPath, "customer", "img", "category", deletedImageFileName);

                if (System.IO.File.Exists(deletedImageFilePath))
                {
                    System.IO.File.Delete(deletedImageFilePath);
                }
            }

        }
    }
}
