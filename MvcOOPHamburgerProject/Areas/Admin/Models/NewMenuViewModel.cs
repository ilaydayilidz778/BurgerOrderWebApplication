using MvcOOPHamburgerProject.Data.Entities.Enums;
using System.ComponentModel.DataAnnotations;
using System;
using MvcOOPHamburgerProject.Data.Entities.Concrete;
using MvcOOPHamburgerProject.Attributes;

namespace MvcOOPHamburgerProject.Areas.Admin.Models
{
    public class NewMenuViewModel
    {
        [Required(ErrorMessage = "{0} is required.")]
        [Display(Name = "Name")]
        [MaxLength(50, ErrorMessage = "Maximum character length for {0} should be {1}.")]
        public string Name { get; set; } = null!;


        [Required(ErrorMessage = "{0} is required.")]
        [Display(Name = "Price")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal Price { get; set; }


        [Required(ErrorMessage = "{0} is required.")]
        [Display(Name = "Size")]
        public Size Size { get; set; } = 0;


        [Required(ErrorMessage = "{0} is required.")]
        [Display(Name = "Status")]
        public Status Status { get; set; } = 0;

        [ValidImage]
        public IFormFile? Image { get; set; }

    }
}
