using MvcOOPHamburgerProject.Attributes;
using MvcOOPHamburgerProject.Data.Entities.Concrete;
using System.ComponentModel.DataAnnotations;

namespace MvcOOPHamburgerProject.Areas.Admin.Models
{
    public class NewCategoryViewModel
    {
        [Required(ErrorMessage ="{0} is required.")]
        [Display(Name = "Name")]
        [MaxLength(30, ErrorMessage = "Maximum character length for {0} should be {1}.")]
        public string Name { get; set; } = null!;

        [ValidImage]
        public IFormFile? Image { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        [Display(Name = "Description")]
        [MaxLength(255, ErrorMessage = "Maximum character length for {0} should be {1}.")]
        public string? Description { get; set; }
    }
}
