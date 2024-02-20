namespace MvcOOPHamburgerProject.Data.Entities.Concrete
{
    public class MenuProduct
    {
        public int Id { get; set; }
        public int MenuId { get; set; }
        public Menu Menu { get; set; } = null!;
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;
        public int Quantity { get; set; }
    }
}
