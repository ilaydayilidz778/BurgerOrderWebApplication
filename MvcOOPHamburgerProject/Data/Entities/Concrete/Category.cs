using System.ComponentModel.DataAnnotations;

namespace MvcOOPHamburgerProject.Data.Entities.Concrete
{
    public class Category
    {
        public int Id { get; set; }

        [MaxLength(25)]
        public string Name { get; set; } = null!;

        public List<Product> Products { get; set; } = new();

        public string? ImageUrl { get; set; }

        public string? Description { get; set; }
    }
}
