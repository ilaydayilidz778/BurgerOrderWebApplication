using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using MvcOOPHamburgerProject.Areas.Admin.Models;
using MvcOOPHamburgerProject.Data.Context;
using MvcOOPHamburgerProject.Data.Entities.Concrete;
using MvcOOPHamburgerProject.Data.Entities.Enums;
using MvcOOPHamburgerProject.Models;
using Newtonsoft.Json;
using NuGet.Versioning;
using System.Diagnostics;
using System.Security.Cryptography;

namespace MvcOOPHamburgerProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;
        private readonly OurMenuViewModel _ourMenuViewModel;
        private readonly UserManager<User> _userManager;
        private readonly IMemoryCache _cache;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db, OurMenuViewModel ourMenuViewModel, UserManager<User> userManager, IMemoryCache cache)
        {
            _logger = logger;
            _db = db;
            _ourMenuViewModel = ourMenuViewModel;
            _userManager = userManager;
            _cache = cache;
        }

        public IActionResult Index(int? categoryId)
        {
            return View();
        }

        public async Task<IActionResult> About()
        {

            return View(await _db.Abouts.ToListAsync());
        }

        public async Task<IActionResult> Testimonial()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> OurMenu(int? categoryId)
        {
            return ViewComponent("OurMenu", new { categoryId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OurMenu(int? menuId, int? productId, int quantitiy)
        {
            try
            {
                var user = await _userManager.GetUserAsync(User);
                var userId = user?.Id; // Kullanýcý null deðilse userId'e ata, null ise null olarak býrak

                if (userId == null)
                {
                    // Kullanýcý giriþ yapmamýþsa, giriþ yapmalarý için yönlendir
                    TempData["ErrorMessage"] = "You must be logged in.";
                }

                var order = await _db.Orders.FirstOrDefaultAsync(o => o.Status == OrderStatus.Pending && o.UserId == userId);

                if (order == null)
                {
                    order = new Order();
                    order.UserId = userId;
                    order.Date = DateTime.Now;
                    _db.Orders.Add(order);
                    await _db.SaveChangesAsync();
                }

                if (productId != null)
                {
                    var selectedProduct = await _db.Products.FindAsync(productId);
                    if (selectedProduct != null)
                    {
                        var orderDetail = new OrderDetail
                        {
                            ProductId = selectedProduct.Id,
                            Product = selectedProduct,
                            Quantity = quantitiy,
                            TotalPrice = selectedProduct.Quantity * selectedProduct.Price,
                        };

                        order.OrderDetails.Add(orderDetail);
                        await _db.SaveChangesAsync();
                    }
                    else
                    {
                        // Ürün bulunamadý hatasý
                        TempData["ErrorMessage"] = "Selected product not found.";
                    }
                }
                else if (menuId != null)
                {
                    var selectedMenu = await _db.Menus.FindAsync(menuId);
                    if (selectedMenu != null)
                    {
                        var orderDetail = new OrderDetail
                        {
                            MenuId = selectedMenu.Id,
                            Menu = selectedMenu,
                            Quantity = quantitiy,
                            TotalPrice = selectedMenu.Quantity * selectedMenu.Price,
                        };

                        order.OrderDetails.Add(orderDetail);
                        await _db.SaveChangesAsync();
                    }
                    else
                    {
                        // Menü bulunamadý hatasý
                        TempData["ErrorMessage"] = "Selected menu not found.";
                    }
                }
                else
                {
                    // Geçersiz istek hatasý
                    TempData["ErrorMessage"] = "Invalid request.";
                }

                // Order ve OrderDetails'i ayrý ayrý oturuma ekleyin
                HttpContext.Session.SetString("orderId", order.Id.ToString());

                return RedirectToAction("OurMenu");
            }
            catch (Exception ex)
            {
                // Genel bir hata durumunda
                TempData["ErrorMessage"] = "An error occurred while processing your request.";
                // Loglama veya diðer iþlemler burada yapýlabilir
                return RedirectToAction("OurMenu");
            }
        }

        [Authorize(Roles = "Admin, Customer")]
        public async Task<IActionResult> Card()
        {
            try
            {
                var orderId = HttpContext.Session.GetString("orderId");

                if (string.IsNullOrEmpty(orderId))
                {
                    var user = await _userManager.GetUserAsync(User);
                    var userId = user?.Id; // Kullanýcý null deðilse userId'e ata, null ise null olarak býrak

                    if (userId == null)
                    {
                        // Kullanýcý giriþ yapmamýþsa, giriþ yapmalarý için yönlendir
                        TempData["ErrorMessage"] = "You must be logged in.";
                    }

                    var userOrder = await _db.Orders.FirstOrDefaultAsync(o => o.Status == OrderStatus.Pending && o.UserId == userId);
                    if (userOrder != null)
                    {
                        HttpContext.Session.SetString("orderId", userOrder.Id.ToString());
                        orderId = userOrder.Id.ToString();
                    }
                    else
                    {

                        TempData["ErrorMessage"] = "Your cart is currently empty.";
                        return RedirectToAction("Index", "Home"); // Deðiþiklik: Boþ sepet durumunda anasayfaya yönlendirme
                    }
                }

                var order = await _db.Orders
                    .Include(o => o.OrderDetails)
                        .ThenInclude(od => od.Product)
                    .Include(o => o.OrderDetails)
                        .ThenInclude(od => od.Menu)
                    .FirstOrDefaultAsync(o => o.Id == int.Parse(orderId));

                if (order == null)
                {
                    TempData["ErrorMessage"] = "Order not found.";
                    return RedirectToAction("Index", "Home"); // Deðiþiklik: Sipariþ bulunamadýðýnda anasayfaya yönlendirme
                }

                decimal totalPrice = 0;
                foreach (OrderDetail orderDetail in order.OrderDetails)
                {
                    if (orderDetail.Product != null)
                    {
                        totalPrice += orderDetail.Product.Price;
                    }
                    else if (orderDetail.Menu != null)
                    {
                        totalPrice += orderDetail.Menu.Price;
                    }
                }
                order.TotalPrice = totalPrice;

                return View(order);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "An error occurred while processing your request.";
                return RedirectToAction("Index", "Home"); // Deðiþiklik: Hata durumunda anasayfaya yönlendirme
            }

        }

        [HttpPost]
        public async Task<IActionResult> DeleteOrderDetail(int? orderDetailId)
        {
            try
            {
                if (orderDetailId == null)
                {
                    TempData["ErrorMessage"] = "Order detail ID is null.";
                    return RedirectToAction("Card", "Home");
                }

                var deletedOrderDetail = await _db.OrderDetails.FindAsync(orderDetailId);
                if (deletedOrderDetail == null)
                {
                    TempData["ErrorMessage"] = "Order detail not found.";
                    return RedirectToAction("Card", "Home");
                }

                _db.OrderDetails.Remove(deletedOrderDetail);
                await _db.SaveChangesAsync();

                // Eðer buraya kadar herhangi bir hata olmadýysa, iþlem baþarýlýdýr.
                TempData["SuccessMessage"] = "Order detail successfully deleted.";
                return RedirectToAction("Card", "Home");
            }
            catch (Exception)
            {
                // Hata durumunda uygun iþlem yapýlabilir, örneðin loglama.
                TempData["ErrorMessage"] = "An error occurred while deleting the order detail.";
                return RedirectToAction("Card", "Home");
            }
        }

        [HttpGet]
        public async Task<IActionResult> EditOrderDetail(int? orderDetailId)
        {
            try
            {
                if (orderDetailId == null)
                {
                    TempData["ErrorMessage"] = "Order detail ID is null.";
                    return RedirectToAction("Card", "Home");
                }

                var editOrderDetail = await _db.OrderDetails.FindAsync(orderDetailId);
                if (editOrderDetail == null)
                {
                    TempData["ErrorMessage"] = "Order detail not found.";
                    return RedirectToAction("Card", "Home");
                }

                var editOrderDetailViewModel = new EditOrderDetailViewModel();

                editOrderDetailViewModel.Id = editOrderDetail.Id;
                editOrderDetailViewModel.OrderId = editOrderDetail.OrderId;
                editOrderDetailViewModel.ProductId = editOrderDetail.ProductId;
                editOrderDetailViewModel.MenuId = editOrderDetail.MenuId;
                editOrderDetailViewModel.Quantity = editOrderDetail.Quantity;
                editOrderDetailViewModel.TotalPrice = editOrderDetail.TotalPrice;

                // ProductList
                var productList = await _db.Products.Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.Name
                }).ToListAsync();

                // MenuList
                var menuList = await _db.Menus.Select(m => new SelectListItem
                {
                    Value = m.Id.ToString(),
                    Text = m.Name 
                }).ToListAsync();

                ViewData["ProductList"] = productList;
                ViewData["MenuList"] = menuList;
                return PartialView("_EditOrderDetailPartial", editOrderDetailViewModel);
            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = "An error occurred while deleting the order detail.";
                return RedirectToAction("Card", "Home");
            }

        }

        [HttpPost]
        public async Task<IActionResult> EditOrderDetail(int? orderDetailId, EditOrderDetailViewModel editOrderDetailViewModel)
        {
            try
            {
                if (orderDetailId == null)
                {
                    TempData["ErrorMessage"] = "Order detail ID is null.";
                    return RedirectToAction("Card", "Home");
                }
                var editOrderDetail = await _db.OrderDetails.FindAsync(orderDetailId);
                if (editOrderDetail == null)
                {
                    TempData["ErrorMessage"] = "Order detail not found.";
                    return RedirectToAction("Card", "Home");
                }

                editOrderDetail.ProductId = editOrderDetailViewModel.ProductId;
                editOrderDetail.Product = _db.Products.Find(editOrderDetail.ProductId);
                editOrderDetail.MenuId = editOrderDetailViewModel.MenuId;
                editOrderDetail.Menu = _db.Menus.Find(editOrderDetail.MenuId);
                editOrderDetail.Quantity = editOrderDetailViewModel.Quantity;
                editOrderDetail.TotalPrice = editOrderDetailViewModel.TotalPrice;

                _db.Update(editOrderDetail);
                await _db.SaveChangesAsync();

                TempData["SuccessMessage"] = "Order detail successfully edited.";
                return RedirectToAction("Card", "Home");
            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = "An error occurred while editing the order detail.";
                return RedirectToAction("Card", "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmOrder(int? orderId)
        {
            try
            {
                if (orderId == null)
                {
                    TempData["ErrorMessage"] = "Order ID is null.";
                    return RedirectToAction("Card", "Home");
                }

                var confirmedOrder = await _db.Orders.FindAsync(orderId);
                if (confirmedOrder == null)
                {
                    TempData["ErrorMessage"] = "Order not found.";
                    return RedirectToAction("Card", "Home");
                }

                confirmedOrder.Status = OrderStatus.Confirmed;
                confirmedOrder.Date = DateTime.Now;
                await _db.SaveChangesAsync();

                // Order'ýn onay zamanýný ve durumunu cache'e kaydet
                _cache.Set($"{confirmedOrder.Id}_ConfirmedTime", DateTime.Now, TimeSpan.FromMinutes(5));
                _cache.Set($"{confirmedOrder.Id}_Status", confirmedOrder.Status, TimeSpan.FromMinutes(5));

                TempData["SuccessMessage"] = "Order successfully confirmed.";
                return RedirectToAction("Card", "Home");
            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = "An error occurred while confirming the order.";
                return RedirectToAction("Card", "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CancelOrder(int? orderId)
        {
            try
            {
                if (orderId == null)
                {
                    TempData["ErrorMessage"] = "Order ID is null.";
                    return RedirectToAction("Card", "Home");
                }

                // Öncelikle sipariþin onaylanma zamanýný ve durumunu cache'den al
                DateTime? confirmedTime = _cache.Get<DateTime?>($"{orderId}_ConfirmedTime");
                OrderStatus? status = _cache.Get<OrderStatus?>($"{orderId}_Status");

                if (confirmedTime == null || status == null)
                {
                    TempData["ErrorMessage"] = "Unable to find order information.";
                    return RedirectToAction("Card", "Home");
                }

                // Eðer 5 dakikadan fazla süre geçtiyse ve sipariþ ready durumunda ise, iptal edilemez
                if (DateTime.Now - confirmedTime > TimeSpan.FromMinutes(5) && status == OrderStatus.Confirmed)
                {
                    var readyOrder = await _db.Orders.FindAsync(orderId);
                    if (readyOrder == null)
                    {
                        TempData["ErrorMessage"] = "Order not found.";
                        return RedirectToAction("Card", "Home");
                    }

                    readyOrder.Status = OrderStatus.Ready;
                    await _db.SaveChangesAsync();
                    TempData["ErrorMessage"] = "Order cannot be cancelled after 5 minutes.";
                    return RedirectToAction("Card", "Home");
                }

                // Ýptal iþlemi gerçekleþtirilir
                var order = await _db.Orders.FindAsync(orderId);
                _db.Orders.Remove(order);
                await _db.SaveChangesAsync();

                // Önbellekten sipariþin bilgilerini temizle
                _cache.Remove($"{orderId}_ConfirmedTime");
                _cache.Remove($"{orderId}_Status");

                TempData["SuccessMessage"] = "Order successfully cancelled.";
                return RedirectToAction("Card", "Home");
            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = "An error occurred while cancelling the order.";
                return RedirectToAction("Card", "Home");
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
