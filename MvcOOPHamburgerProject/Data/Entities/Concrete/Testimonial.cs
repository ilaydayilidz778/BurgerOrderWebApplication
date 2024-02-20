using System.ComponentModel.DataAnnotations;

namespace MvcOOPHamburgerProject.Data.Entities.Concrete
{
    public class Testimonial
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;

        [Range(1, 5)]
        public int Puan { get; set; } 
        public string ImageUrl { get; set; } = null!;
    }
}
