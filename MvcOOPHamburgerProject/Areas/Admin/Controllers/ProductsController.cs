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
using MvcOOPHamburgerProject.Data.Entities.Enums;

namespace MvcOOPHamburgerProject.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administrator")]
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ProductsController(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // GET: Admin/Products
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Products.Include(p => p.Category);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Admin/Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Admin/Products/Create
        public IActionResult Create()
        {
            ViewData["StatusList"] = Enum.GetValues(typeof(Status))
                              .Cast<Status>()
                              .Select(x => new SelectListItem
                              {
                                  Text = x.ToString(),
                                  Value = ((int)x).ToString()
                              })
                              .ToList();

            ViewData["SizeList"] = Enum.GetValues(typeof(Data.Entities.Enums.Size))
                            .Cast<Data.Entities.Enums.Size>()
                            .Select(x => new SelectListItem
                            {
                                Text = x.ToString(),
                                Value = ((int)x).ToString()
                            })
                            .ToList();
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
            return View();
        }

        // POST: Admin/Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(NewProductViewModel newProductViewModel)
        {
            var product = new Product();
            if (ModelState.IsValid)
            {
                if (_context.Categories.FirstOrDefault(c => c.Name == newProductViewModel.Name) != null)
                {
                    ModelState.AddModelError("", "The category you want to enter already exist");
                }
                else
                {
                    product.Name = newProductViewModel.Name;
                    product.Price = newProductViewModel.Price;
                    product.Size = newProductViewModel.Size;
                    product.Status = newProductViewModel.Status;
                    product.CategoryId = newProductViewModel.CategoryId;

                    string ext = Path.GetExtension(newProductViewModel.Image.FileName);
                    string newFileName = newProductViewModel.Name.Trim().Replace(" ", "") + ext;
                    product.ImageUrl = newFileName;
                    string fileStream = Path.Combine(_env.WebRootPath, "customer", "img", "product", newFileName);

                    RemoveImageFormFile(product);

                    // Dosya yolunu oluştur ve ekle ama bu dasya yolu varsa hata oluştur. File.CreateNew
                    using (var fs = new FileStream(fileStream, FileMode.Create))
                    {
                        newProductViewModel.Image.CopyTo(fs);
                    }

                    _context.Add(product);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index), new { Result = "Added" });
                }
            }
            ViewData["StatusList"] = Enum.GetValues(typeof(Status))
                                .Cast<Status>()
                                .Select(x => new SelectListItem
                                {
                                    Text = x.ToString(),
                                    Value = ((int)x).ToString()
                                })
                                .ToList();

            ViewData["SizeList"] = Enum.GetValues(typeof(Data.Entities.Enums.Size))
                                        .Cast<Data.Entities.Enums.Size>()
                                        .Select(x => new SelectListItem
                                        {
                                            Text = x.ToString(),
                                            Value = ((int)x).ToString()
                                        })
                                        .ToList();
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", product.CategoryId);
            return View(newProductViewModel);
        }

        // GET: Admin/Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            var editProductViewModel = new EditProductViewModel()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Size = product.Size,
                Status = product.Status,
                ImageUrl = product.ImageUrl,
                CategoryId = product.CategoryId,
            };
            ViewData["StatusList"] = Enum.GetValues(typeof(Status))
                               .Cast<Status>()
                               .Select(x => new SelectListItem
                               {
                                   Text = x.ToString(),
                                   Value = ((int)x).ToString()
                               })
                               .ToList();

            ViewData["SizeList"] = Enum.GetValues(typeof(Data.Entities.Enums.Size))
                                        .Cast<Data.Entities.Enums.Size>()
                                        .Select(x => new SelectListItem
                                        {
                                            Text = x.ToString(),
                                            Value = ((int)x).ToString()
                                        })
                                        .ToList();
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", product.CategoryId);
            return View(editProductViewModel);
        }

        // POST: Admin/Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,Size,Status,ImageUrl,CategoryId,Image")] EditProductViewModel editProductViewModel)
        {
            if (id != editProductViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var product = await _context.Products.FindAsync(id);

                    if (product == null)
                    {
                        return NotFound();
                    }

                    if (_context.Products.Any(p => p.Name == editProductViewModel.Name && p.Id != editProductViewModel.Id))
                    {
                        ModelState.AddModelError("", "The product you want to update already exists");
                    }
                    else
                    {
                        product.Name = editProductViewModel.Name;
                        product.Price = editProductViewModel.Price;
                        product.Size = editProductViewModel.Size;
                        product.Status = editProductViewModel.Status;
                        product.CategoryId = editProductViewModel.CategoryId;

                        if (editProductViewModel.Image != null)
                        {
                            RemoveImageFormFile(product);

                            string ext = Path.GetExtension(editProductViewModel.Image.FileName);
                            string newFileName = editProductViewModel.Name.Trim().Replace(" ", "") + ext;
                            product.ImageUrl = newFileName;
                            string fileStream = Path.Combine(_env.WebRootPath, "customer", "img", "product", newFileName);

                            using (var fs = new FileStream(fileStream, FileMode.Create))
                            {
                                editProductViewModel.Image.CopyTo(fs);
                            }
                        }

                        _context.Update(product);
                        await _context.SaveChangesAsync();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(editProductViewModel.Id))
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

            ViewData["StatusList"] = Enum.GetValues(typeof(Status))
                                .Cast<Status>()
                                .Select(x => new SelectListItem
                                {
                                    Text = x.ToString(),
                                    Value = ((int)x).ToString()
                                })
                                .ToList();

            ViewData["SizeList"] = Enum.GetValues(typeof(Data.Entities.Enums.Size))
                                         .Cast<Data.Entities.Enums.Size>()
                                         .Select(x => new SelectListItem
                                         {
                                             Text = x.ToString(),
                                             Value = ((int)x).ToString()
                                         })
                                         .ToList();
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", editProductViewModel.CategoryId);
            return View(editProductViewModel);
        }


        // GET: Admin/Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Admin/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, Product product)
        {
            product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                RemoveImageFormFile(product);
                _context.Products.Remove(product);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { Result = "Deleted" });
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }

        public void RemoveImageFormFile(Product product)
        {
            if (product.ImageUrl != null)
            {
                string deletedImageFileName = product.ImageUrl;
                string deletedImageFilePath = Path.Combine(_env.WebRootPath, "customer", "img", "product", deletedImageFileName);

                if (System.IO.File.Exists(deletedImageFilePath))
                {
                    System.IO.File.Delete(deletedImageFilePath);
                }
            }
        }
    }
}
