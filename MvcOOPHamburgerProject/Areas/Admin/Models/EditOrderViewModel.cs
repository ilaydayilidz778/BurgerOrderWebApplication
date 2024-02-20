using MvcOOPHamburgerProject.Data.Entities.Concrete;
using MvcOOPHamburgerProject.Data.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace MvcOOPHamburgerProject.Areas.Admin.Models
{
    public class EditOrderViewModel
    {
        public int Id { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal TotalPrice { get; set; }

        public OrderStatus Status { get; set; } = (OrderStatus)0;

        public string UserId { get; set; } = null!;

    }
}
