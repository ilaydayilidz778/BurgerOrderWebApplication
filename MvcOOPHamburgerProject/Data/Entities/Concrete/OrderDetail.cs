using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MvcOOPHamburgerProject.Data.Entities.Concrete
{
    public class OrderDetail
    {
        public int Id { get; set; }

        public int Quantity { get; set; } = 1;

        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal TotalPrice { get; set; }

        public int OrderId { get; set; }

        [JsonIgnore]
        public Order Order { get; set; } = null!;

        public int? ProductId { get; set; }

        public Product? Product { get; set; }

        public int? MenuId { get; set; }

        public Menu? Menu { get; set; }
    }
}