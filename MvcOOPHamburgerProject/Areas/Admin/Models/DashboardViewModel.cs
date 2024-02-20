using MvcOOPHamburgerProject.Data.Entities.Concrete;

namespace MvcOOPHamburgerProject.Areas.Admin.Models
{
    public class DashboardViewModel
    {
        public User TopOrderingCustomer { get; set; }
        public City MostOrderedCity { get; set; }
        public Product MostOrderedProduct { get; set; }
        public decimal YearlyRevenue { get; set; }
        public decimal MonthlyRevenue { get; set; }
        public Product MostPreferredProduct { get; set; }
        public Menu MostPreferredMenu { get; set; }
        public string BestSellingCategory { get; set; }
        public List<Testimonial> LastTenComments { get; set; }
        public List<Menu> LastTenMenus { get; set; }
        public int TotalUserCount { get; set; }
    }
}
