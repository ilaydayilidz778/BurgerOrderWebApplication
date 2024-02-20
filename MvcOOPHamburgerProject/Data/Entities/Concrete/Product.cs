namespace MvcOOPHamburgerProject.Data.Entities.Concrete
{
    public class Product : BaseProduct
    {
        public int CategoryId { get; set; }


        public Category Category { get; set; } = null!;

        public List<MenuProduct> MenuProducts { get; set; } = new();
    }
}
