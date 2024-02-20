using System.ComponentModel.DataAnnotations;

namespace MvcOOPHamburgerProject.Data.Entities.Concrete
{
    public class Address
    {
        public int Id { get; set; }

        [MaxLength(25)]
        public string Title { get; set; } = null!;

        public int CityId { get; set; }

        public City City { get; set; } = null!;

        [MaxLength(25)]
        public string PostalCode { get; set; } = null!;

        [MaxLength(200)]
        public string Description { get; set; } = null!;

        public string UserId { get; set; }

        public User User { get; set; } = null!;
    }
}
