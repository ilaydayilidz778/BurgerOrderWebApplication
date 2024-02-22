using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MvcOOPHamburgerProject.Data.Entities.Concrete;
using MvcOOPHamburgerProject.Data.Entities.Enums;
using System;

namespace MvcOOPHamburgerProject.Data.Context
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<MenuProduct> MenuProduct { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Slider> Silders { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Slider>().HasData(
              new Slider
              {
                  Id = 1,
                  Title = "Who We Are?",
                  Description = "We offer hamburgers prepared with the freshest and highest quality ingredients in our restaurant. Our aim is to provide our guests with a delicious and healthy dining experience.",
                  ImageUrl = "slider1.jpg",
                  Number = 1,
              },
               new Slider
               {
                   Id = 2,
                   Title = "Our Mission",
                   Description = "Our mission is to provide the best service to our customers and exceed their expectations. We prioritize customer satisfaction with our hamburgers made with quality ingredients and our sincere service approach.",
                   ImageUrl = "slider2.jpg",
                   Number = 2,
               },
              new Slider
              {
                  Id = 3,
                  Title = "Our Vision",
                  Description = "Our vision is to be an innovative and leading brand in the industry and ensure sustainable growth. We aim to win the admiration of our customers by constantly offering new flavors and experiences.",
                  ImageUrl = "silider3.jpg",
                  Number = 3,
              }
              );

            builder.Entity<About>().HasData(
                new About
                {
                    Id = 1,
                    Title = "Who We Are?",
                    SubTitle = "Offering Delicious and Healthy Hamburgers",
                    Description = "We offer hamburgers prepared with the freshest and highest quality ingredients in our restaurant. Our aim is to provide our guests with a delicious and healthy dining experience.",
                    ImageUrl = "about1.jpg"
                },
                 new About
                 {
                     Id = 2,
                     Title = "Our Mission",
                     SubTitle = "Service Focused on Customer Satisfaction",
                     Description = "Our mission is to provide the best service to our customers and exceed their expectations. We prioritize customer satisfaction with our hamburgers made with quality ingredients and our sincere service approach.",
                     ImageUrl = "about2.jpg"
                 },
                new About
                {
                    Id = 3,
                    Title = "Our Vision",
                    SubTitle = "Innovative and Sustainable Growth",
                    Description = "Our vision is to be an innovative and leading brand in the industry and ensure sustainable growth. We aim to win the admiration of our customers by constantly offering new flavors and experiences.",
                    ImageUrl = "about3.jpg"
                }
                );


            builder.Entity<Testimonial>().HasData(
                  new Testimonial
                  {
                      Id = 1,
                      Title = "Great Experience!",
                      Description = "I had a fantastic experience at the restaurant. The burgers were delicious and the service was excellent.",
                      Puan = 5,
                      ImageUrl = "clientChef1.jpg"
                  },
                new Testimonial
                {
                    Id = 2,
                    Title = "Amazing Burgers!",
                    Description = "The burgers here are amazing! I loved every bite. Can't wait to come back again!",
                    Puan = 4,
                    ImageUrl = "clientChef2.jpg"
                },
                new Testimonial
                {
                    Id = 3,
                    Title = "Best Burgers in Town!",
                    Description = "These burgers are hands down the best in town. The taste is unmatched!",
                    Puan = 5,
                    ImageUrl = "clientChef3.jpg"
                }

                );

            builder.Entity<Category>().HasData(
                    new Category
                    {
                        Id = 1,
                        Name = "Burger",
                        ImageUrl = "CategoryBurger.png",
                        Description = "Savor the succulent taste of our juicy burger creations, crafted with premium ingredients and grilled to perfection."
                    },
                    new Category
                    {
                        Id = 2,
                        Name = "Dessert",
                        ImageUrl = "CategoryDessert.png",
                        Description = "Indulge your sweet tooth with our delightful array of desserts, ranging from decadent cakes to mouthwatering pastries."
                    },
                    new Category
                    {
                        Id = 3,
                        Name = "Ingredient",
                        ImageUrl = "CategoryIngredient.png",
                        Description = "Explore our diverse selection of high-quality ingredients, sourced from trusted suppliers to elevate your culinary creations."
                    },
                    new Category
                    {
                        Id = 4,
                        Name = "Snack",
                        ImageUrl = "CategorySnack.png",
                        Description = "Satiate your cravings on the go with our convenient snack options, perfect for satisfying hunger anytime, anywhere."
                    },
                    new Category
                    {
                        Id = 5,
                        Name = "Drink",
                        ImageUrl = "CategoryDrink.png",
                        Description = "Quench your thirst with our refreshing range of beverages, from classic sodas to exotic fruit-infused cocktails."
                    }
                );

            // Burgerler
            builder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Classic Big Tasty", Price = 9.99m, Size = Size.Standard, ImageUrl = "ClassicBigTasty.jpg", CategoryId = 1 },
                new Product { Id = 2, Name = "Chicken Big Tasty", Price = 10.99m, Size = Size.Standard, ImageUrl = "ChickenBigTasty.jpg", CategoryId = 1 },
                new Product { Id = 3, Name = "Double Spicy Chicken (Classic)", Price = 12.99m, Size = Size.Standard, ImageUrl = "DoubleSpicyChicken(Classic).jpg", CategoryId = 1 },
                new Product { Id = 4, Name = "National Burger", Price = 8.99m, Size = Size.Standard, ImageUrl = "NationalBurger.jpg", CategoryId = 1 },
                new Product { Id = 5, Name = "Spicy Chicken (Classic)", Price = 7.99m, Size = Size.Standard, ImageUrl = "SpicyChicken(Classic).jpg", CategoryId = 1 },
                new Product { Id = 6, Name = "McChicken", Price = 6.99m, Size = Size.Standard, ImageUrl = "McChicken.jpg", CategoryId = 1 },
                new Product { Id = 7, Name = "Crispy Chicken Burger", Price = 5.99m, Size = Size.Standard, ImageUrl = "CrispyChickenBurger.jpg", CategoryId = 1 },
                new Product { Id = 8, Name = "Quarter Pounder", Price = 8.49m, Size = Size.Standard, ImageUrl = "QuarterPounder.jpg", CategoryId = 1 },
                new Product { Id = 9, Name = "Double Beef Burger", Price = 11.99m, Size = Size.Standard, ImageUrl = "DoubleBeefBurger.jpg", CategoryId = 1 },
                new Product { Id = 10, Name = "Beef Burger", Price = 7.49m, Size = Size.Standard, ImageUrl = "BeefBurger.jpg", CategoryId = 1 },
                new Product { Id = 11, Name = "Daba Daba Burger", Price = 10.49m, Size = Size.Standard, ImageUrl = "DabaDabaBurger.jpg", CategoryId = 1 },
                new Product { Id = 12, Name = "Double Big Mac", Price = 12.99m, Size = Size.Standard, ImageUrl = "DoubleBigMac.jpg", CategoryId = 1 },
                new Product { Id = 13, Name = "Double Cheeseburger", Price = 9.49m, Size = Size.Standard, ImageUrl = "DoubleCheeseburger.jpg", CategoryId = 1 },
                new Product { Id = 14, Name = "Double McChicken", Price = 10.99m, Size = Size.Standard, ImageUrl = "DoubleMcChicken.jpg", CategoryId = 1 },
                new Product { Id = 15, Name = "Double Quarter Pounder", Price = 11.49m, Size = Size.Standard, ImageUrl = "DoubleQuarterPounder.jpg", CategoryId = 1 },
                new Product { Id = 16, Name = "Big Mac", Price = 9.99m, Size = Size.Standard, ImageUrl = "BigMac.jpg", CategoryId = 1 },
                new Product { Id = 17, Name = "Hamburger", Price = 5.99m, Size = Size.Standard, ImageUrl = "Hamburger.jpg", CategoryId = 1 },
                new Product { Id = 18, Name = "Cheeseburger", Price = 6.49m, Size = Size.Standard, ImageUrl = "Cheeseburger.jpg", CategoryId = 1 }
            );

            // Tatlılar
            builder.Entity<Product>().HasData(
                new Product { Id = 19, Name = "Forest Fruit Muffin", Price = 3.79m, Size = Size.Standard, ImageUrl = "ForestFruitMuffin.jpg", CategoryId = 2 },
                new Product { Id = 20, Name = "Strawberry Filled White Chocolate Donut", Price = 4.29m, Size = Size.Standard, ImageUrl = "StrawberryFilledWhiteChocolateDonut.jpg", CategoryId = 2 },
                new Product { Id = 21, Name = "Strawberry White Chocolate Decorated Donut", Price = 4.49m, Size = Size.Standard, ImageUrl = "StrawberryWhiteChocolateDecoratedDonut.jpg", CategoryId = 2 },
                new Product { Id = 22, Name = "Chocolate Cake", Price = 6.99m, Size = Size.Standard, ImageUrl = "ChocolateCake.jpg", CategoryId = 2 },
                new Product { Id = 23, Name = "Hazelnut Cream Filled Cocoa Donut", Price = 3.99m, Size = Size.Standard, ImageUrl = "HazelnutCreamFilledCocoaDonut.jpg", CategoryId = 2 },
                new Product { Id = 26, Name = "Brownie", Price = 4.49m, Size = Size.Standard, ImageUrl = "Brownie.jpg", CategoryId = 2 },
                new Product { Id = 27, Name = "Chocolate Muffin", Price = 3.79m, Size = Size.Standard, ImageUrl = "ChocolateMuffin.jpg", CategoryId = 2 },
                new Product { Id = 29, Name = "Carrot Cake", Price = 4.99m, Size = Size.Standard, ImageUrl = "CarrotCake.jpg", CategoryId = 2 },
                new Product { Id = 30, Name = "Hazelnut Cookie", Price = 2.49m, Size = Size.Standard, ImageUrl = "HazelnutCookie.jpg", CategoryId = 2 },
                new Product { Id = 31, Name = "Raspberry Chocolate Cake", Price = 6.99m, Size = Size.Standard, ImageUrl = "RaspberryChocolateCake.jpg", CategoryId = 2 },
                new Product { Id = 34, Name = "Triple Chocolate Cookie", Price = 2.99m, Size = Size.Standard, ImageUrl = "TripleChocolateCookie.jpg", CategoryId = 2 },
                new Product { Id = 35, Name = "SenSebastian Cheesecake", Price = 6.49m, Size = Size.Standard, ImageUrl = "SenSebastianCheesecake.jpg", CategoryId = 2 },
                new Product { Id = 36, Name = "Red Velvet Cake", Price = 6.99m, Size = Size.Standard, ImageUrl = "RedVelvetCake.jpg", CategoryId = 2 },
                new Product { Id = 37, Name = "Tiramisu", Price = 5.49m, Size = Size.Standard, ImageUrl = "Tiramisu.jpg", CategoryId = 2 }
            );

            // Soslar
            builder.Entity<Product>().HasData(
                new Product { Id = 38, Name = "Ketchup (Packet)", Price = 0.99m, Size = Size.Standard, ImageUrl = "Ketchup(Packet).jpg", CategoryId = 3 },
                new Product { Id = 39, Name = "Mayonnaise (Packet)", Price = 0.99m, Size = Size.Standard, ImageUrl = "Mayonnaise(Packet).jpg", CategoryId = 3 },
                new Product { Id = 40, Name = "Garlic Mayonnaise (Packet)", Price = 1.29m, Size = Size.Standard, ImageUrl = "GarlicMayonnaise(Packet).jpg", CategoryId = 3 },
                new Product { Id = 41, Name = "Hot Sauce (Packet)", Price = 1.29m, Size = Size.Standard, ImageUrl = "HotSauce(Packet).jpg", CategoryId = 3 },
                new Product { Id = 42, Name = "Barbecue Sauce", Price = 2.49m, Size = Size.Standard, ImageUrl = "BarbecueSauce.jpg", CategoryId = 3 },
                new Product { Id = 43, Name = "Mustard Sauce", Price = 1.99m, Size = Size.Standard, ImageUrl = "MustardSauce.jpg", CategoryId = 3 },
                new Product { Id = 44, Name = "Ranch Sauce", Price = 2.29m, Size = Size.Standard, ImageUrl = "RanchSauce.jpg", CategoryId = 3 },
                new Product { Id = 45, Name = "Buffalo Sauce", Price = 2.99m, Size = Size.Standard, ImageUrl = "BuffaloSauce.jpg", CategoryId = 3 }
            );

            // Atıştırmalıklar
            builder.Entity<Product>().HasData(
                new Product { Id = 46, Name = "Large French Fries", Price = 4.99m, Size = Size.Large, ImageUrl = "LargeFrenchFries.jpg", CategoryId = 4 },
                new Product { Id = 47, Name = "Medium French Fries", Price = 3.99m, Size = Size.Medium, ImageUrl = "MediumFrenchFries.jpg", CategoryId = 4 },
                new Product { Id = 48, Name = "Small French Fries", Price = 2.99m, Size = Size.Small, ImageUrl = "SmallFrenchFries.jpg", CategoryId = 4 },
                new Product { Id = 49, Name = "Crispy Onions (8-piece)", Price = 5.99m, Size = Size.Standard, ImageUrl = "CrispyOnions(8-piece).jpg", CategoryId = 4 },
                new Product { Id = 50, Name = "Crispy Onions (12-piece)", Price = 7.99m, Size = Size.Standard, ImageUrl = "CrispyOnions(12-piece).jpg", CategoryId = 4 },
                new Product { Id = 51, Name = "Crispy Onions (16-piece)", Price = 9.99m, Size = Size.Standard, ImageUrl = "CrispyOnions(16-piece).jpg", CategoryId = 4 },
                new Product { Id = 52, Name = "Waffle Fries (Large)", Price = 5.99m, Size = Size.Large, ImageUrl = "WaffleFries(Large).jpg", CategoryId = 4 },
                new Product { Id = 53, Name = "Waffle Fries (Medium)", Price = 4.99m, Size = Size.Medium, ImageUrl = "WaffleFries(Medium).jpg", CategoryId = 4 },
                new Product { Id = 54, Name = "Waffle Fries (Small)", Price = 3.99m, Size = Size.Small, ImageUrl = "WaffleFries(Small).jpg", CategoryId = 4 },
                new Product { Id = 55, Name = "2-Piece Crispy Tenders", Price = 6.99m, Size = Size.Standard, ImageUrl = "2-PieceCrispyTenders.jpg", CategoryId = 4 },
                new Product { Id = 56, Name = "4-Piece Crispy Tenders", Price = 10.99m, Size = Size.Standard, ImageUrl = "4-PieceCrispyTenders.jpg", CategoryId = 4 }
            );

            // İçecekler
            builder.Entity<Product>().HasData(
                 new Product { Id = 57, Name = "Mixology (Mango)", Price = 15.99m, Size = Size.Standard, ImageUrl = "Mixology(Mango).jpg", CategoryId = 5 },
                 new Product { Id = 58, Name = "Mixology (Strawberry)", Price = 12.49m, Size = Size.Standard, ImageUrl = "Mixology(Strawberry).jpg", CategoryId = 5 },
                 new Product { Id = 59, Name = "Mixology (Mint)", Price = 18.79m, Size = Size.Standard, ImageUrl = "Mixology(Mint).jpg", CategoryId = 5 },
                 new Product { Id = 60, Name = "Coca-Cola Zero Sugar (Small)", Price = 11.99m, Size = Size.Small, ImageUrl = "Coca-ColaZeroSugar(Small).jpg", CategoryId = 5 },
                 new Product { Id = 61, Name = "Coca-Cola Zero Sugar (Medium)", Price = 13.29m, Size = Size.Medium, ImageUrl = "Coca-ColaZeroSugar(Medium).jpg", CategoryId = 5 },
                 new Product { Id = 62, Name = "Coca-Cola Zero Sugar (Large)", Price = 14.99m, Size = Size.Large, ImageUrl = "Coca-ColaZeroSugar(Large).jpg", CategoryId = 5 },
                 new Product { Id = 63, Name = "Coca-Cola (Small)", Price = 12.49m, Size = Size.Small, ImageUrl = "Coca-Cola(Small).jpg", CategoryId = 5 },
                 new Product { Id = 64, Name = "Coca-Cola (Medium)", Price = 11.79m, Size = Size.Medium, ImageUrl = "Coca-Cola(Medium).jpg", CategoryId = 5 },
                 new Product { Id = 65, Name = "Coca-Cola (Large)", Price = 15.49m, Size = Size.Large, ImageUrl = "Coca-Cola(Large).jpg", CategoryId = 5 },
                 new Product { Id = 66, Name = "Fanta (Small)", Price = 10.99m, Size = Size.Small, ImageUrl = "Fanta(Small).jpg", CategoryId = 5 },
                 new Product { Id = 67, Name = "Fanta (Medium)", Price = 12.29m, Size = Size.Medium, ImageUrl = "Fanta(Medium).jpg", CategoryId = 5 },
                 new Product { Id = 68, Name = "Fanta (Large)", Price = 13.49m, Size = Size.Large, ImageUrl = "Fanta(Large).jpg", CategoryId = 5 },
                 new Product { Id = 69, Name = "Sprite (Small)", Price = 11.49m, Size = Size.Small, ImageUrl = "Sprite(Small).jpg", CategoryId = 5 },
                 new Product { Id = 70, Name = "Sprite (Medium)", Price = 14.99m, Size = Size.Medium, ImageUrl = "Sprite(Medium).jpg", CategoryId = 5 },
                 new Product { Id = 71, Name = "Sprite (Large)", Price = 16.79m, Size = Size.Large, ImageUrl = "Sprite(Large).jpg", CategoryId = 5 },
                 new Product { Id = 72, Name = "Fuse Tea Peach (Small)", Price = 10.49m, Size = Size.Small, ImageUrl = "FuseTeaPeach(Small).jpg", CategoryId = 5 },
                 new Product { Id = 73, Name = "Fuse Tea Peach (Medium)", Price = 12.99m, Size = Size.Medium, ImageUrl = "FuseTeaPeach(Medium).jpg", CategoryId = 5 },
                 new Product { Id = 74, Name = "Fuse Tea Peach (Large)", Price = 14.49m, Size = Size.Large, ImageUrl = "FuseTeaPeach(Large).jpg", CategoryId = 5 },
                 new Product { Id = 75, Name = "Fuse Tea Lemon (Small)", Price = 11.29m, Size = Size.Small, ImageUrl = "FuseTeaLemon(Small).jpg", CategoryId = 5 },
                 new Product { Id = 76, Name = "Fuse Tea Lemon (Medium)", Price = 13.79m, Size = Size.Medium, ImageUrl = "FuseTeaLemon(Medium).jpg", CategoryId = 5 },
                 new Product { Id = 77, Name = "Fuse Tea Lemon (Large)", Price = 15.99m, Size = Size.Large, ImageUrl = "FuseTeaLemon(Large).jpg", CategoryId = 5 },
                 new Product { Id = 78, Name = "Strawberry Milkshake (Small)", Price = 17.49m, Size = Size.Small, ImageUrl = "StrawberryMilkshake(Small).jpg", CategoryId = 5 },
                 new Product { Id = 79, Name = "Strawberry Milkshake (Medium)", Price = 0, Size = Size.Medium, ImageUrl = "StrawberryMilkshake(Medium).jpg", CategoryId = 5 },
                 new Product { Id = 80, Name = "Strawberry Milkshake (Large)", Price = 0, Size = Size.Large, ImageUrl = "StrawberryMilkshake(Large).jpg", CategoryId = 5 },
                 new Product { Id = 81, Name = "Coffee Milkshake (Small)", Price = 0, Size = Size.Small, ImageUrl = "CoffeeMilkshake(Small).jpg", CategoryId = 5 },
                 new Product { Id = 82, Name = "Coffee Milkshake (Medium)", Price = 0, Size = Size.Medium, ImageUrl = "CoffeeMilkshake(Medium).jpg", CategoryId = 5 },
                 new Product { Id = 83, Name = "Coffee Milkshake (Large)", Price = 0, Size = Size.Large, ImageUrl = "CoffeeMilkshake(Large).jpg", CategoryId = 5 },
                 new Product { Id = 84, Name = "Chocolate Milkshake (Small)", Price = 0, Size = Size.Small, ImageUrl = "ChocolateMilkshake(Small).jpg", CategoryId = 5 },
                 new Product { Id = 85, Name = "Chocolate Milkshake (Medium)", Price = 0, Size = Size.Medium, ImageUrl = "ChocolateMilkshake(Medium).jpg", CategoryId = 5 },
                 new Product { Id = 86, Name = "Chocolate Milkshake (Large)", Price = 0, Size = Size.Large, ImageUrl = "ChocolateMilkshake(Large).jpg", CategoryId = 5 },
                 new Product { Id = 87, Name = "Water", Price = 2.49m, Size = Size.Standard, ImageUrl = "Water.jpg", CategoryId = 5 },
                 new Product { Id = 88, Name = "Ayran", Price = 1.99m, Size = Size.Standard, ImageUrl = "Ayran.jpg", CategoryId = 5 }
             );

            // Menüler
            builder.Entity<Menu>().HasData(
                new Menu { Id = 1, Name = "Big Mac Menu", Price = 59.99m, Size = Entities.Enums.Size.Standard, ImageUrl = "BigMacMenu.jpg" },
                new Menu { Id = 2, Name = "Double Big Mac Menu", Price = 92.99m, Size = Entities.Enums.Size.Standard, ImageUrl = "DoubleBigMacMenu.jpg" },
                new Menu { Id = 3, Name = "Double McEconomical Menu", Price = 51.99m, Size = Entities.Enums.Size.Standard, ImageUrl = "DoubleMcEconomicalMenu.jpg" },
                new Menu { Id = 4, Name = "Triple McEconomical Menu", Price = 74.99m, Size = Entities.Enums.Size.Standard, ImageUrl = "TripleMcEconomicalMenu.jpg" },
                new Menu { Id = 5, Name = "Burger with Meat and Crispy Chicken Offer Menu", Price = 13.99m, Size = Entities.Enums.Size.Standard, ImageUrl = "BurgerwithMeatandCrispyChickenOfferMenu.jpg" },
                new Menu { Id = 6, Name = "Double Big Tasty Menu", Price = 54.99m, Size = Entities.Enums.Size.Standard, ImageUrl = "DoubleBigTastyMenu.jpg" },
                new Menu { Id = 7, Name = "Gamer Menu", Price = 86.99m, Size = Entities.Enums.Size.Standard, ImageUrl = "GamerMenu.jpg" },
                new Menu { Id = 8, Name = "Legendary Duo (Big Mac + McChicken) Menu", Price = 71.99m, Size = Entities.Enums.Size.Standard, ImageUrl = "LegendaryDuo(BigMac+McChicken).jpg" },
                new Menu { Id = 9, Name = "Triple Big Mac Offer", Price = 65.99m, Size = Entities.Enums.Size.Standard, ImageUrl = "TripleBigMacOffer.jpg" },
                new Menu { Id = 10, Name = "Double Meatball Burger Menu", Price = 53.99m, Size = Entities.Enums.Size.Standard, ImageUrl = "DoubleMeatballBurgerMenu.jpg" },
                new Menu { Id = 11, Name = "Meatball Burger Offer Menu", Price = 51.99m, Size = Entities.Enums.Size.Standard, ImageUrl = "MeatballBurgerOfferMenu.jpg" },
                new Menu { Id = 12, Name = "Crispy Chicken Offer Menu", Price = 60.99m, Size = Entities.Enums.Size.Standard, ImageUrl = "CrispyChickenOfferMenu.jpg" },
                new Menu { Id = 13, Name = "Classic Big Tasty Menu", Price = 52.99m, Size = Entities.Enums.Size.Standard, ImageUrl = "ClassicBigTastyMenu.jpg" },
                new Menu { Id = 14, Name = "Chicken Big Tasty Menu", Price = 83.99m, Size = Entities.Enums.Size.Standard, ImageUrl = "ChickenBigTastyMenu.jpg" },
                new Menu { Id = 15, Name = "National Burger Menu", Price = 91.99m, Size = Entities.Enums.Size.Standard, ImageUrl = "NationalBurgerMenu.jpg" },
                new Menu { Id = 16, Name = "Double Spicy Chicken (Classic) Menu", Price = 80.99m, Size = Entities.Enums.Size.Standard, ImageUrl = "DoubleSpicyChicken(Classic)Menu.jpg" }
            );

            builder.Entity<MenuProduct>().HasData(
                // Big Mac™ Menü
                new MenuProduct { Id = 1, MenuId = 1, ProductId = 6, Quantity = 2 }, // Big Mac
                new MenuProduct { Id = 2, MenuId = 1, ProductId = 7, Quantity = 2 }, // Patates Kızartması (Orta)
                new MenuProduct { Id = 3, MenuId = 1, ProductId = 50, Quantity = 2 }, // Coca-Cola

                // İkili Big Mac™ Menü
                new MenuProduct { Id = 4, MenuId = 2, ProductId = 6, Quantity = 2 }, // Big Mac
                new MenuProduct { Id = 5, MenuId = 2, ProductId = 6, Quantity = 2 }, // Big Mac (İkinci Adet)
                new MenuProduct { Id = 6, MenuId = 2, ProductId = 7, Quantity = 2 }, // Patates Kızartması (Orta)
                new MenuProduct { Id = 7, MenuId = 2, ProductId = 50, Quantity = 2 }, // Coca-Cola (1 L.)

                // İkili Mekonomik Menü
                new MenuProduct { Id = 8, MenuId = 3, ProductId = 9, Quantity = 2 }, // Quarter Pounder (İlk Adet)
                new MenuProduct { Id = 9, MenuId = 3, ProductId = 9, Quantity = 2 }, // Quarter Pounder (İkinci Adet)
                new MenuProduct { Id = 10, MenuId = 3, ProductId = 7, Quantity = 2 }, // Patates Kızartması (Orta) (İlk Adet)
                new MenuProduct { Id = 11, MenuId = 3, ProductId = 7, Quantity = 2 }, // Patates Kızartması (Orta) (İkinci Adet)
                new MenuProduct { Id = 12, MenuId = 3, ProductId = 50, Quantity = 2 }, // Coca-Cola (İlk Adet)
                new MenuProduct { Id = 13, MenuId = 3, ProductId = 50, Quantity = 2 }, // Coca-Cola (İkinci Adet)

                // 3'lü Mekonomik Menü
                new MenuProduct { Id = 14, MenuId = 4, ProductId = 11, Quantity = 2 }, // Köfte Burger (İlk Adet)
                new MenuProduct { Id = 15, MenuId = 4, ProductId = 11, Quantity = 2 }, // Köfte Burger (İkinci Adet)
                new MenuProduct { Id = 16, MenuId = 4, ProductId = 8, Quantity = 2 }, // McChicken
                new MenuProduct { Id = 17, MenuId = 4, ProductId = 7, Quantity = 2 }, // Patates Kızartması (Orta) (İlk Adet)
                new MenuProduct { Id = 18, MenuId = 4, ProductId = 7, Quantity = 2 }, // Patates Kızartması (Orta) (İkinci Adet)
                new MenuProduct { Id = 19, MenuId = 4, ProductId = 50, Quantity = 2 }, // Coca-Cola (İlk Adet)
                new MenuProduct { Id = 20, MenuId = 4, ProductId = 50, Quantity = 2 }, // Coca-Cola (İkinci Adet)

                // Köfte Burgerli ve Çıtır Tavuklu Fırsat Menü
                new MenuProduct { Id = 21, MenuId = 5, ProductId = 11, Quantity = 2 }, // Köfte Burger (İlk Adet)
                new MenuProduct { Id = 22, MenuId = 5, ProductId = 11, Quantity = 2 }, // Köfte Burger (İkinci Adet)
                new MenuProduct { Id = 23, MenuId = 5, ProductId = 12, Quantity = 2 }, // Çıtır Tavuk Burger (İlk Adet)
                new MenuProduct { Id = 24, MenuId = 5, ProductId = 12, Quantity = 2 }, // Çıtır Tavuk Burger (İkinci Adet)
                new MenuProduct { Id = 25, MenuId = 5, ProductId = 7, Quantity = 2 }, // Büyük Boy Patates Kızartması
                new MenuProduct { Id = 26, MenuId = 5, ProductId = 13, Quantity = 2 }, // Sos (İlk Adet)
                new MenuProduct { Id = 27, MenuId = 5, ProductId = 13, Quantity = 2 }, // Sos (İkinci Adet)
                new MenuProduct { Id = 28, MenuId = 5, ProductId = 50, Quantity = 2 }, // Orta Boy İçecek (İlk Adet)
                new MenuProduct { Id = 29, MenuId = 5, ProductId = 50, Quantity = 2 }, // Orta Boy İçecek (İkinci Adet)

                // 2'li Big Tasty Menü
                new MenuProduct { Id = 30, MenuId = 6, ProductId = 3, Quantity = 2 }, // Klasik Big Tasty
                new MenuProduct { Id = 31, MenuId = 6, ProductId = 4, Quantity = 2 }, // Tavuklu Big Tasty
                new MenuProduct { Id = 32, MenuId = 6, ProductId = 7, Quantity = 2 }, // Patates Kızartması (Büyük)
                new MenuProduct { Id = 33, MenuId = 6, ProductId = 50, Quantity = 2 }, // Coca-Cola (1 L.)

                // Gamer Menü
                new MenuProduct { Id = 34, MenuId = 7, ProductId = 6, Quantity = 1 }, // Big Mac
                new MenuProduct { Id = 35, MenuId = 7, ProductId = 7, Quantity = 1 }, // Patates Kızartması (Orta)
                new MenuProduct { Id = 36, MenuId = 7, ProductId = 14, Quantity = 1 }, // Chicken McNuggets (4'lü)
                new MenuProduct { Id = 37, MenuId = 7, ProductId = 50, Quantity = 1 }, // Coca-Cola (Orta)

                // Efsane İkili (Big Mac™ + McChicken™)
                new MenuProduct { Id = 38, MenuId = 8, ProductId = 6, Quantity = 1 }, // Big Mac
                new MenuProduct { Id = 39, MenuId = 8, ProductId = 8, Quantity = 1 }, // McChicken
                new MenuProduct { Id = 40, MenuId = 8, ProductId = 7, Quantity = 1 }, // Patates Kızartması (Orta)
                new MenuProduct { Id = 41, MenuId = 8, ProductId = 50, Quantity = 1 }, // Coca-Cola (1 L.)

                // 3’lü Big Mac™ Fırsatı
                new MenuProduct { Id = 42, MenuId = 9, ProductId = 6, Quantity = 3 }, // Big Mac (İlk Adet)
                new MenuProduct { Id = 43, MenuId = 9, ProductId = 7, Quantity = 1 }, // Orta Boy Patates
                new MenuProduct { Id = 44, MenuId = 9, ProductId = 50, Quantity = 1 }, // Coca-Cola (1 L.)

                // 2'li Double Köfteburger Menü
                new MenuProduct { Id = 45, MenuId = 10, ProductId = 15, Quantity = 2 }, // Double Köfteburger (İlk Adet)
                new MenuProduct { Id = 46, MenuId = 10, ProductId = 7, Quantity = 1 }, // Patates Kızartması (Orta)
                new MenuProduct { Id = 47, MenuId = 10, ProductId = 50, Quantity = 1 }, // Coca-Cola (1 L.)

                // Köfte Burgerli Fırsat Menüsü
                new MenuProduct { Id = 48, MenuId = 11, ProductId = 11, Quantity = 4 }, // Köfte Burger (İlk Adet)
                new MenuProduct { Id = 49, MenuId = 11, ProductId = 7, Quantity = 1 }, // Büyük Boy Patates Kızartması
                new MenuProduct { Id = 50, MenuId = 11, ProductId = 13, Quantity = 2 }, // Sos (İlk Adet)
                new MenuProduct { Id = 51, MenuId = 11, ProductId = 50, Quantity = 2 }, // Orta Boy İçecek (İlk Adet)

                // Çıtır Tavuklu Fırsat Menüsü
                new MenuProduct { Id = 52, MenuId = 12, ProductId = 12, Quantity = 4 }, // Çıtır Tavuk Burger (İlk Adet)
                new MenuProduct { Id = 53, MenuId = 12, ProductId = 7, Quantity = 1 }, // Büyük Boy Patates Kızartması
                new MenuProduct { Id = 54, MenuId = 12, ProductId = 13, Quantity = 2 }, // Sos (İlk Adet)
                new MenuProduct { Id = 55, MenuId = 12, ProductId = 50, Quantity = 2 }, // Orta Boy İçecek (İlk Adet)

                // Klasik Big Tasty Menü
                new MenuProduct { Id = 56, MenuId = 13, ProductId = 3, Quantity = 1 }, // Klasik Big Tasty
                new MenuProduct { Id = 57, MenuId = 13, ProductId = 7, Quantity = 1 }, // Patates Kızartması (Orta)
                new MenuProduct { Id = 58, MenuId = 13, ProductId = 50, Quantity = 1 }, // Coca-Cola

                // Tavuklu Big Tasty Menü
                new MenuProduct { Id = 59, MenuId = 14, ProductId = 4, Quantity = 1 }, // Tavuklu Big Tasty
                new MenuProduct { Id = 60, MenuId = 14, ProductId = 7, Quantity = 1 }, // Patates Kızartması (Orta)
                new MenuProduct { Id = 61, MenuId = 14, ProductId = 50, Quantity = 1 }, // Coca-Cola

                // Milli Burger Menü
                new MenuProduct { Id = 62, MenuId = 15, ProductId = 16, Quantity = 1 }, // Milli Burger
                new MenuProduct { Id = 63, MenuId = 15, ProductId = 7, Quantity = 1 }, // Patates Kızartması (Orta)
                new MenuProduct { Id = 64, MenuId = 15, ProductId = 50, Quantity = 1 }, // Coca-Cola

                // Double Acılı Tavuk (Klasik) Menü
                new MenuProduct { Id = 65, MenuId = 16, ProductId = 17, Quantity = 1 }, // Double Acılı Tavuk (Klasik)
                new MenuProduct { Id = 66, MenuId = 16, ProductId = 7, Quantity = 1 }, // Patates Kızartması (Orta)
                new MenuProduct { Id = 67, MenuId = 16, ProductId = 50, Quantity = 1 } // Coca-Cola
            );


            builder.Entity<City>().HasData(
                new City { Id = 1, Name = "Adana" },
                new City { Id = 2, Name = "Adıyaman" },
                new City { Id = 3, Name = "Afyonkarahisar" },
                new City { Id = 4, Name = "Ağrı" },
                new City { Id = 5, Name = "Amasya" },
                new City { Id = 6, Name = "Ankara" },
                new City { Id = 7, Name = "Antalya" },
                new City { Id = 8, Name = "Artvin" },
                new City { Id = 9, Name = "Aydın" },
                new City { Id = 10, Name = "Balıkesir" },
                new City { Id = 11, Name = "Bilecik" },
                new City { Id = 12, Name = "Bingöl" },
                new City { Id = 13, Name = "Bitlis" },
                new City { Id = 14, Name = "Bolu" },
                new City { Id = 15, Name = "Burdur" },
                new City { Id = 16, Name = "Bursa" },
                new City { Id = 17, Name = "Çanakkale" },
                new City { Id = 18, Name = "Çankırı" },
                new City { Id = 19, Name = "Çorum" },
                new City { Id = 20, Name = "Denizli" },
                new City { Id = 21, Name = "Diyarbakır" },
                new City { Id = 22, Name = "Edirne" },
                new City { Id = 23, Name = "Elazığ" },
                new City { Id = 24, Name = "Erzincan" },
                new City { Id = 25, Name = "Erzurum" },
                new City { Id = 26, Name = "Eskişehir" },
                new City { Id = 27, Name = "Gaziantep" },
                new City { Id = 28, Name = "Giresun" },
                new City { Id = 29, Name = "Gümüşhane" },
                new City { Id = 30, Name = "Hakkari" },
                new City { Id = 31, Name = "Hatay" },
                new City { Id = 32, Name = "Isparta" },
                new City { Id = 33, Name = "Mersin" },
                new City { Id = 34, Name = "İstanbul" },
                new City { Id = 35, Name = "İzmir" },
                new City { Id = 36, Name = "Kars" },
                new City { Id = 37, Name = "Kastamonu" },
                new City { Id = 38, Name = "Kayseri" },
                new City { Id = 39, Name = "Kırklareli" },
                new City { Id = 40, Name = "Kırşehir" },
                new City { Id = 41, Name = "Kocaeli" },
                new City { Id = 42, Name = "Konya" },
                new City { Id = 43, Name = "Kütahya" },
                new City { Id = 44, Name = "Malatya" },
                new City { Id = 45, Name = "Manisa" },
                new City { Id = 46, Name = "Kahramanmaraş" },
                new City { Id = 47, Name = "Mardin" },
                new City { Id = 48, Name = "Muğla" },
                new City { Id = 49, Name = "Muş" },
                new City { Id = 50, Name = "Nevşehir" },
                new City { Id = 51, Name = "Niğde" },
                new City { Id = 52, Name = "Ordu" },
                new City { Id = 53, Name = "Rize" },
                new City { Id = 54, Name = "Sakarya" },
                new City { Id = 55, Name = "Samsun" },
                new City { Id = 56, Name = "Siirt" },
                new City { Id = 57, Name = "Sinop" },
                new City { Id = 58, Name = "Sivas" },
                new City { Id = 59, Name = "Tekirdağ" },
                new City { Id = 60, Name = "Tokat" },
                new City { Id = 61, Name = "Trabzon" },
                new City { Id = 62, Name = "Tunceli" },
                new City { Id = 63, Name = "Şanlıurfa" },
                new City { Id = 64, Name = "Uşak" },
                new City { Id = 65, Name = "Van" },
                new City { Id = 66, Name = "Yozgat" },
                new City { Id = 67, Name = "Zonguldak" },
                new City { Id = 68, Name = "Aksaray" },
                new City { Id = 69, Name = "Bayburt" },
                new City { Id = 70, Name = "Karaman" },
                new City { Id = 71, Name = "Kırıkkale" },
                new City { Id = 72, Name = "Batman" },
                new City { Id = 73, Name = "Şırnak" },
                new City { Id = 74, Name = "Bartın" },
                new City { Id = 75, Name = "Ardahan" },
                new City { Id = 76, Name = "Iğdır" },
                new City { Id = 77, Name = "Yalova" },
                new City { Id = 78, Name = "Karabük" },
                new City { Id = 79, Name = "Kilis" },
                new City { Id = 80, Name = "Osmaniye" },
                new City { Id = 81, Name = "Düzce" }
            );
        }
    }
}
