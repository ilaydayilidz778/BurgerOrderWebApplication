using MvcOOPHamburgerProject.Data.Entities.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MvcOOPHamburgerProject.Data.Entities.Concrete
{
    public class Order
    {
        public int Id { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal TotalPrice { get; set; }

        public OrderStatus Status { get; set; } = (OrderStatus)0;

        [JsonIgnore]
        public List<OrderDetail> OrderDetails { get; set; } = new();

        public string UserId { get; set; } = null!;

        public User User { get; set; } = null!;
    }
}
