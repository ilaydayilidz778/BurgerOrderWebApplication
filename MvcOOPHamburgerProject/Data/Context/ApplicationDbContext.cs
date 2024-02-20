using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MvcOOPHamburgerProject.Data.Entities.Concrete;
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

            builder.Entity<Product>().HasData(
             new Product
             {
                 Id = 1,
                 Name = "Cola",
                 Price = 2.99m,
                 Size = Entities.Enums.Size.Small,
                 ImageUrl = "Cola.png",
                 CategoryId = 5
             },
             new Product
             {
                 Id = 2,
                 Name = "French Fries",
                 Price = 1.99m,
                 Size = Entities.Enums.Size.Medium,
                 ImageUrl = "FrenchFries.png",
                 CategoryId = 4
             },
             new Product
             {
                 Id = 3,
                 Name = "Double Beef Burger",
                 Price = 23.99m,
                 Size = Entities.Enums.Size.Standard,
                 ImageUrl = "DoubleBeefBurger.jpg",
                 CategoryId = 1
             },
             new Product
             {
                 Id = 4,
                 Name = "Crispy Chicken Extra",
                 Price = 17.99m,
                 Size = Entities.Enums.Size.Standard,
                 ImageUrl = "CrispyChickenExtra.jpg",
                 CategoryId = 1
             },
             new Product
             {
                 Id = 5,
                 Name = "Classic Big Tasty",
                 Price = 21.99m,
                 Size = Entities.Enums.Size.Standard,
                 ImageUrl = "ClassicBigTasty.png",
                 CategoryId = 1
             },
             new Product
             {
                 Id = 6,
                 Name = "McChicken",
                 Price = 14.99m,
                 Size = Entities.Enums.Size.Standard,
                 ImageUrl = "McChicken.jpg",
                 CategoryId = 1
             },
             new Product
             {
                 Id = 7,
                 Name = "Chicken Big Tasty",
                 Price = 16.99m,
                 Size = Entities.Enums.Size.Standard,
                 ImageUrl = "ChickenBigTasty.jpg",
                 CategoryId = 1
             },
             new Product
             {
                 Id = 8,
                 Name = "Double Cheeseburger",
                 Price = 9.99m,
                 Size = Entities.Enums.Size.Standard,
                 ImageUrl = "DoubleCheeseburger.jpg",
                 CategoryId = 1
             },
              new Product
              {
                  Id = 10,
                  Name = "Sprite",
                  Price = 5.99m,
                  ImageUrl = "Sprite.png",
                  CategoryId = 5
              },
              new Product
              {
                  Id = 11,
                  Name = "Blueberry Sauce Ice Cream",
                  Price = 7.99m,
                  ImageUrl = "BlueberrySauceIceCream.png",
                  CategoryId = 2
              },
              new Product
              { 
                Id = 12,
                Name = "Caramel Sauce Ice Cream",
                Price = 7.99m,
                ImageUrl = "CaramelSauceIceCream.png",
                CategoryId = 2
              },
              new Product
              {
                Id = 13,
                Name = "Oreo Milkshake",
                Price = 5.99m,
                ImageUrl = "OreoMilkshake.png",
                CategoryId = 5 
              });

            builder.Entity<Menu>().HasData(
                new Menu
                {
                    Id = 1,
                    Name = "McChicken Menü",
                    Price = 18.99m,
                    Size = Entities.Enums.Size.Large,
                    ImageUrl = "McChickenMenu.jpg",
                },
                new Menu
                {
                    Id = 2,
                    Name = "Big Tasty Menü",
                    Price = 15.99m,
                    Size = Entities.Enums.Size.Medium,
                    ImageUrl = "BigTastyMenu.png",
                },
                new Menu
                {
                    Id = 3,
                    Name = "Double Cheeseburger + McChicken® Menü",
                    Price = 23.99m,
                    Size = Entities.Enums.Size.Large,
                    ImageUrl = "DoubleCheeseBurgerMcChickenMenu.png",
                },
                new Menu
                {
                    Id = 4,
                    Name = "Çıtır Tavuklu Fırsat Menüsü",
                    Price = 17.99m,
                    Size = Entities.Enums.Size.Small,
                    ImageUrl = "CitirTavukluFirsatMenusu.png",
                },
                new Menu
                {
                    Id = 5,
                    Name = "Üçlü Mekonomik Menü",
                    Price = 21.99m,
                    Size = Entities.Enums.Size.Large,
                    ImageUrl = "UcluMekonomikMenu.png",

                });

            builder.Entity<MenuProduct>().HasData(
                new MenuProduct { Id = 1, MenuId = 1, ProductId = 6 },
                new MenuProduct { Id = 2, MenuId = 1, ProductId = 1 },
                new MenuProduct { Id = 3, MenuId = 1, ProductId = 2 },

                new MenuProduct { Id = 4, MenuId = 2, ProductId = 5 },
                new MenuProduct { Id = 5, MenuId = 2, ProductId = 1 },
                new MenuProduct { Id = 6, MenuId = 2, ProductId = 2 },

                new MenuProduct { Id = 7, MenuId = 3, ProductId = 8 },
                new MenuProduct { Id = 8, MenuId = 3, ProductId = 6 },
                new MenuProduct { Id = 9, MenuId = 3, ProductId = 1, Quantity = 2 },
                new MenuProduct { Id = 10, MenuId = 3, ProductId = 2, Quantity = 2 },

                new MenuProduct { Id = 11, MenuId = 4, ProductId = 4, Quantity = 4 },
                new MenuProduct { Id = 12, MenuId = 4, ProductId = 1, Quantity = 2 },
                new MenuProduct { Id = 13, MenuId = 4, ProductId = 2 },

                new MenuProduct { Id = 14, MenuId = 5, ProductId = 8, Quantity = 3 },
                new MenuProduct { Id = 15, MenuId = 5, ProductId = 1, Quantity = 3 },
                new MenuProduct { Id = 16, MenuId = 5, ProductId = 2, Quantity = 3 }
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
