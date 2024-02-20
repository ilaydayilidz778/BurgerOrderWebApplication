using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MvcOOPHamburgerProject.Data.Entities.Concrete
{
    public class User : IdentityUser
    {

        [MaxLength(25)]
        public string FirstName { get; set; } = null!;

        [MaxLength(25)]
        public string LastName { get; set; } = null!;
        public List<Order> Orders { get; set; } = new();

        public List<Address> Addresses { get; set; } = new();
    }
}
