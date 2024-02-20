using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcOOPHamburgerProject.Areas.Admin.Models;
using MvcOOPHamburgerProject.Data.Context;
using MvcOOPHamburgerProject.Data.Entities.Concrete;
using MvcOOPHamburgerProject.Data.Entities.Enums;

namespace MvcOOPHamburgerProject.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administrator")]
    [Area("Admin")]
    public class MenusController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly NewMenuViewModel _newMenuViewModel;

        public MenusController(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // GET: Admin/Menus
        public async Task<IActionResult> Index()
        {
            return View(await _context.Menus
                .Include(m => m.MenuProducts)
                .ThenInclude(mp => mp.Product)
                .ToListAsync());

        }

        // GET: Admin/Menus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menu = await _context.Menus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (menu == null)
            {
                return NotFound();
            }

            return View(menu);
        }

        // GET: Admin/Menus/Create
        public IActionResult Create()
        {
            ViewData["StatusList"] = Enum.GetValues(typeof(Status)).Cast<Status>()
                .Select(x => new SelectListItem { Text = x.ToString(), Value = ((int)x).ToString() }).ToList();
            ViewData["SizeList"] = Enum.GetValues(typeof(Size)).Cast<Size>()
                .Select(x => new SelectListItem { Text = x.ToString(), Value = ((int)x).ToString() }).ToList();
            return View();
        }

        // POST: Admin/Menus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(NewMenuViewModel newMenuViewModel)
        {
            if (ModelState.IsValid)
            {
                var menu = new Menu();

                menu.Name = newMenuViewModel.Name;
                menu.Price = newMenuViewModel.Price;
                menu.Size = newMenuViewModel.Size;
                menu.Status = newMenuViewModel.Status;

                string ext = Path.GetExtension(newMenuViewModel.Image.FileName);
                string newFileName = newMenuViewModel.Name.Trim().Replace(" ", "") + ext;
                menu.ImageUrl = newFileName;

                string fileStream = Path.Combine(_env.WebRootPath, "customer", "img", "menu", newFileName);
                using (var fs = new FileStream(fileStream, FileMode.Create))
                {
                    newMenuViewModel.Image.CopyTo(fs);
                }

                _context.Add(menu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { Result = "Added" });
            }

            ViewData["StatusList"] = Enum.GetValues(typeof(Status)).Cast<Status>()
                .Select(x => new SelectListItem { Text = x.ToString(), Value = ((int)x).ToString() }).ToList();
            ViewData["SizeList"] = Enum.GetValues(typeof(Size)).Cast<Size>()
                .Select(x => new SelectListItem { Text = x.ToString(), Value = ((int)x).ToString() }).ToList();
            return View(newMenuViewModel);
        }

        // GET: Admin/Menus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menu = await _context.Menus.FindAsync(id);
            if (menu == null)
            {
                return NotFound();
            }

            var editMenuViewModel = new EditMenuViewModel()
            {
                Id = menu.Id,
                Name = menu.Name,
                Price = menu.Price,
                Size = menu.Size,
                Status = menu.Status,
                ImageUrl = menu.ImageUrl
            };

            ViewData["StatusList"] = Enum.GetValues(typeof(Status)).Cast<Status>()
              .Select(x => new SelectListItem { Text = x.ToString(), Value = ((int)x).ToString() }).ToList();
            ViewData["SizeList"] = Enum.GetValues(typeof(Size)).Cast<Size>()
                .Select(x => new SelectListItem { Text = x.ToString(), Value = ((int)x).ToString() }).ToList();
            return View(editMenuViewModel);
        }

        // POST: Admin/Menus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditMenuViewModel editMenuViewModel)
        {
            if (id != editMenuViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var menu = await _context.Menus.FindAsync(id);

                    if (menu == null)
                    {
                        return NotFound();
                    }

                    if (_context.Products.Any(p => p.Name == editMenuViewModel.Name && p.Id != editMenuViewModel.Id))
                    {
                        ModelState.AddModelError("", "The product you want to update already exists");
                    }
                    else
                    {

                        menu.Name = editMenuViewModel.Name;
                        menu.Price = editMenuViewModel.Price;
                        menu.Size = editMenuViewModel.Size;
                        menu.Status = editMenuViewModel.Status;
                        if (editMenuViewModel.Image != null)
                        {
                            RemoveImageFormFile(menu);

                            string ex = Path.GetExtension(editMenuViewModel.Image.FileName);
                            string newFileName = editMenuViewModel.Name.Trim().Replace("", " ") + ex;
                            menu.ImageUrl = newFileName;

                            string fileStream = Path.Combine(_env.WebRootPath, "customer", "img", "menu", newFileName);
                            using (var fs = new FileStream(fileStream, FileMode.Create))
                            {
                                editMenuViewModel.Image.CopyTo(fs);
                            }
                        }
                    }

                    _context.Update(menu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MenuExists(editMenuViewModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new {Result = "Updated"});
            }

            ViewData["StatusList"] = Enum.GetValues(typeof(Status)).Cast<Status>()
                .Select(x => new SelectListItem { Text = x.ToString(), Value = ((int)x).ToString() }).ToList();
            ViewData["SizeList"] = Enum.GetValues(typeof(Size)).Cast<Size>()
                .Select(x => new SelectListItem { Text = x.ToString(), Value = ((int)x).ToString() }).ToList();

            return View(editMenuViewModel);
        }

        // GET: Admin/Menus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menu = await _context.Menus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (menu == null)
            {
                return NotFound();
            }

            return View(menu);
        }

        // POST: Admin/Menus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var menu = await _context.Menus.FindAsync(id);
            if (menu != null)
            {
                RemoveImageFormFile(menu);
                _context.Menus.Remove(menu);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new {Result = "Delted"});
        }

        private bool MenuExists(int id)
        {
            return _context.Menus.Any(e => e.Id == id);
        }

        public void RemoveImageFormFile(Menu menu)
        {
            if (menu.ImageUrl != null)
            {
                string deletedImageFileName = menu.ImageUrl;
                string deletedImageFilePath = Path.Combine(_env.WebRootPath, "customer", "img", "product", deletedImageFileName);

                if (System.IO.File.Exists(deletedImageFilePath))
                {
                    System.IO.File.Delete(deletedImageFilePath);
                }
            }
        }
    }
}
