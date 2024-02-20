using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MvcOOPHamburgerProject.Data.Entities.Concrete;

namespace MvcOOPHamburgerProject.Data.Context
{
    public class AplicationDbContextSeed
    {
        public static async Task SeedAsync(RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            if (!await roleManager.RoleExistsAsync("Administrator"))
            {
                await roleManager.CreateAsync(new IdentityRole("Administrator"));

                if (!await userManager.Users.AnyAsync(u => u.UserName == "admin@example.com"))
                {
                    var user = new User()
                    {
                        FirstName = "Jhon",
                        LastName = "Doe",
                        UserName = "admin@example.com",
                        Email = "admin@example.com",
                        EmailConfirmed = true,
                        Addresses = new List<Address>()
                    };

                    var address = new Address()
                    {
                        Title = "Home Address",
                        CityId = 34,
                        PostalCode = "34367",
                        Description = "Askerocağı caddesi No:6. Elmadağ / Şişli  İstanbul",
                        UserId = user.Id
                    };
                    await userManager.CreateAsync(user, "P@ssword1");
                    await userManager.AddToRoleAsync(user, "Administrator");
                }
            }

            if (!await roleManager.RoleExistsAsync("Customer"))
            {
                await roleManager.CreateAsync(new IdentityRole("Customer"));

                var user = new User()
                {
                    FirstName = "İlayda",
                    LastName = "Yıldız",
                    UserName = "ilaydayildiz@example.com",
                    Email = "ilaydayildiz@example.com",
                    EmailConfirmed = true,
                    Addresses = new List<Address>()
                };

                var address = new Address()
                {
                    Title = "Home Address",
                    CityId = 34,
                    PostalCode = "11300",
                    Description = "Kasımpaşa Mahallesi, 106 Sokak, Hazal Apartmanı, No:10, Kat:4, Daire:4 Bozüyük / Bilecik",
                    UserId = user.Id
                };
                await userManager.CreateAsync(user, "P@ssword1");
                await userManager.AddToRoleAsync(user, "Customer");

            }

        }
    }
}
