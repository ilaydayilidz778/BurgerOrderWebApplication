using MvcOOPHamburgerProject.Data.Entities.Concrete;

namespace MvcOOPHamburgerProject.Areas.Admin.Models
{
    public class NewMenuProductViewModel
    {
        public int MenuId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; } 
    }
}
