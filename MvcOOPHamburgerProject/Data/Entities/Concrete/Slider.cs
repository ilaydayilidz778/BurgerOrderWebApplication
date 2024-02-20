using System.ComponentModel.DataAnnotations;

namespace MvcOOPHamburgerProject.Data.Entities.Concrete
{
    public class Slider
    {
        public int Id { get; set; }
        public string? ImageUrl { get; set; } = null!;

        [MaxLength(50)]
        public string Title { get; set; } = null!;

        [MaxLength(255)]
        public string Description { get; set; } = null!;

        public int Number { get; set; } 
    }
}

