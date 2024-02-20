using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcOOPHamburgerProject.Areas.Admin.Models;
using MvcOOPHamburgerProject.Data.Context;
using MvcOOPHamburgerProject.Data.Entities.Concrete;

namespace MvcOOPHamburgerProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MenuProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MenuProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/MenuProducts
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.MenuProduct.Include(m => m.Menu).Include(m => m.Product);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Admin/MenuProducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuProduct = await _context.MenuProduct
                .Include(m => m.Menu)
                .Include(m => m.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (menuProduct == null)
            {
                return NotFound();
            }

            return View(menuProduct);
        }

        // GET: Admin/MenuProducts/Create
        public IActionResult Create()
        {
            ViewData["MenuId"] = new SelectList(_context.Menus, "Id", "Name");
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Name");
            return View();
        }

        // POST: Admin/MenuProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(NewMenuProductViewModel newMenuProductViewModel)
        {
            if (ModelState.IsValid)
            {
                var menuProduct = new MenuProduct();
                menuProduct.MenuId = newMenuProductViewModel.MenuId;
                menuProduct.ProductId = newMenuProductViewModel.ProductId;
                menuProduct.Quantity = newMenuProductViewModel.Quantity;
                menuProduct.Menu = _context.Menus.FirstOrDefault(m => m.Id == menuProduct.MenuId)!;
                menuProduct.Product = _context.Products.FirstOrDefault(m => m.Id == menuProduct.ProductId)!;

                _context.Add(menuProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { Result = "Added" });
            }
            ViewData["MenuId"] = new SelectList(_context.Menus, "Id", "Name", newMenuProductViewModel.MenuId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Name", newMenuProductViewModel.ProductId);
            return View(newMenuProductViewModel);
        }

        // GET: Admin/MenuProducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuProduct = await _context.MenuProduct.FindAsync(id);
            if (menuProduct == null)
            {
                return NotFound();
            }

            var editMenuProductViewModel = new EditMenuProductViewModel()
            {
                Id = menuProduct.Id,
                MenuId = menuProduct.MenuId,
                ProductId = menuProduct.ProductId,
                Quantity = menuProduct.Quantity,
            };

            ViewData["MenuId"] = new SelectList(_context.Menus, "Id", "Name", menuProduct.MenuId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Name", menuProduct.ProductId);
            return View(editMenuProductViewModel);
        }

        // POST: Admin/MenuProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditMenuProductViewModel editMenuProductViewModel)
        {
            if (id != editMenuProductViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var menuProduct = await _context.MenuProduct.FindAsync(id);
                    if (menuProduct == null)
                    {
                        return NotFound();
                    }

                    menuProduct.Id = editMenuProductViewModel.Id;
                    menuProduct.MenuId = editMenuProductViewModel.MenuId;
                    menuProduct.ProductId = editMenuProductViewModel.ProductId;
                    menuProduct.Quantity = editMenuProductViewModel.Quantity;
                    menuProduct.Menu = _context.Menus.FirstOrDefault(m => m.Id == menuProduct.MenuId)!;
                    menuProduct.Product = _context.Products.FirstOrDefault(m => m.Id == menuProduct.ProductId)!;

                    _context.Update(menuProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MenuProductExists(editMenuProductViewModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new { Result = "Updated" });
            }
            ViewData["MenuId"] = new SelectList(_context.Menus, "Id", "Name", editMenuProductViewModel.MenuId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Name", editMenuProductViewModel.ProductId);
            return View(editMenuProductViewModel);
        }

        // GET: Admin/MenuProducts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuProduct = await _context.MenuProduct
                .Include(m => m.Menu)
                .Include(m => m.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (menuProduct == null)
            {
                return NotFound();
            }

            return View(menuProduct);
        }

        // POST: Admin/MenuProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var menuProduct = await _context.MenuProduct.FindAsync(id);
            if (menuProduct != null)
            {
                _context.MenuProduct.Remove(menuProduct);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MenuProductExists(int id)
        {
            return _context.MenuProduct.Any(e => e.Id == id);
        }
    }
}
