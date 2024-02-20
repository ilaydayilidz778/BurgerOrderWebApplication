using MvcOOPHamburgerProject.Data.Entities.Concrete;

namespace MvcOOPHamburgerProject.Models
{
    public class OurMenuViewModel
    {
        public List<Product>? Products { get; set; }
        public List<Category>? Categories { get; set; }
        public List<Menu>? Menus { get; set; } 
        public int? SelectedCategoryId { get; set; }
    }
}
