namespace MvcOOPHamburgerProject.Data.Entities.Concrete
{
    public class Menu : BaseProduct
    {
        public List<MenuProduct> MenuProducts { get; set; } = new();
    }
}
