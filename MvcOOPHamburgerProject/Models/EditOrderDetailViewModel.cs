using MvcOOPHamburgerProject.Data.Entities.Concrete;
using MvcOOPHamburgerProject.Data.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace MvcOOPHamburgerProject.Models
{
    public class EditOrderDetailViewModel
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal TotalPrice { get; set; }

        public int OrderId { get; set; }

        public int? ProductId { get; set; }

        public int? MenuId { get; set; }

    }
}
