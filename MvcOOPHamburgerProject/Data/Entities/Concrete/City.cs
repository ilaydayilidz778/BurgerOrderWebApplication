using System.ComponentModel.DataAnnotations;

namespace MvcOOPHamburgerProject.Data.Entities.Concrete
{
    public class City
    {
        public int Id { get; set; }

        [MaxLength(25)]
        public string Name { get; set; } = null!;
    }
}
