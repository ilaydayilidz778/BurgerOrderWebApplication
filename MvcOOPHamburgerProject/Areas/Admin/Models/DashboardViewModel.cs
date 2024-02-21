using MvcOOPHamburgerProject.Data.Entities.Concrete;

namespace MvcOOPHamburgerProject.Areas.Admin.Models
{
    public class DashboardViewModel
    {
        // En Çok Sipariş Veren İlk 10 Müşteri
        public string? CustomerName { get; set; }
        public decimal TotalOrdersAmount { get; set; }

        // En çok sipariş edilen ürün
        public string? ProductName { get; set; }
        public int TotalOrdersOfProduct { get; set; }

        // En çok sipariş edilen menü
        public string? MenuName { get; set; }
        public int TotalOrdersOfMenu { get; set; }

        // En çok sipariş verilen ilk 10 şehir
        public string? CityName { get; set; }
        public int TotalOrdersOfCities { get; set; }

        // En çok sipariş edilen ürün kategorileri
        public string? CategoryName { get; set; }
        public int AmountOfCategory { get; set; }
    }
}
