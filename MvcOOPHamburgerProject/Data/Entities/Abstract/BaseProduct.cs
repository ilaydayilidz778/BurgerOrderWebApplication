using MvcOOPHamburgerProject.Data.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace MvcOOPHamburgerProject.Data.Entities.Concrete
{
    public abstract class BaseProduct
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; } = null!;

        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal Price { get; set; }

        public int Quantity { get; set; } = 1;

        public Enums.Size Size { get; set; } = 0;

        public Status Status { get; set; } = (Status)0;

        public string ImageUrl { get; set; } = string.Empty;

    }
}
