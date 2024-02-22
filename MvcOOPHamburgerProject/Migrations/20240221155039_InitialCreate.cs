using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MvcOOPHamburgerProject.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Abouts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abouts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Silders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Silders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Testimonials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Puan = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Testimonials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Addresses_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MenuProduct",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuProduct_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuProduct_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    MenuId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    Emal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Facebook = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Instagram = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Twitter = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contacts_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Abouts",
                columns: new[] { "Id", "Description", "ImageUrl", "SubTitle", "Title" },
                values: new object[,]
                {
                    { 1, "We offer hamburgers prepared with the freshest and highest quality ingredients in our restaurant. Our aim is to provide our guests with a delicious and healthy dining experience.", "about1.jpg", "Offering Delicious and Healthy Hamburgers", "Who We Are?" },
                    { 2, "Our mission is to provide the best service to our customers and exceed their expectations. We prioritize customer satisfaction with our hamburgers made with quality ingredients and our sincere service approach.", "about2.jpg", "Service Focused on Customer Satisfaction", "Our Mission" },
                    { 3, "Our vision is to be an innovative and leading brand in the industry and ensure sustainable growth. We aim to win the admiration of our customers by constantly offering new flavors and experiences.", "about3.jpg", "Innovative and Sustainable Growth", "Our Vision" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 1, "Savor the succulent taste of our juicy burger creations, crafted with premium ingredients and grilled to perfection.", "CategoryBurger.png", "Burger" },
                    { 2, "Indulge your sweet tooth with our delightful array of desserts, ranging from decadent cakes to mouthwatering pastries.", "CategoryDessert.png", "Dessert" },
                    { 3, "Explore our diverse selection of high-quality ingredients, sourced from trusted suppliers to elevate your culinary creations.", "CategoryIngredient.png", "Ingredient" },
                    { 4, "Satiate your cravings on the go with our convenient snack options, perfect for satisfying hunger anytime, anywhere.", "CategorySnack.png", "Snack" },
                    { 5, "Quench your thirst with our refreshing range of beverages, from classic sodas to exotic fruit-infused cocktails.", "CategoryDrink.png", "Drink" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Adana" },
                    { 2, "Adıyaman" },
                    { 3, "Afyonkarahisar" },
                    { 4, "Ağrı" },
                    { 5, "Amasya" },
                    { 6, "Ankara" },
                    { 7, "Antalya" },
                    { 8, "Artvin" },
                    { 9, "Aydın" },
                    { 10, "Balıkesir" },
                    { 11, "Bilecik" },
                    { 12, "Bingöl" },
                    { 13, "Bitlis" },
                    { 14, "Bolu" },
                    { 15, "Burdur" },
                    { 16, "Bursa" },
                    { 17, "Çanakkale" },
                    { 18, "Çankırı" },
                    { 19, "Çorum" },
                    { 20, "Denizli" },
                    { 21, "Diyarbakır" },
                    { 22, "Edirne" },
                    { 23, "Elazığ" },
                    { 24, "Erzincan" },
                    { 25, "Erzurum" },
                    { 26, "Eskişehir" },
                    { 27, "Gaziantep" },
                    { 28, "Giresun" },
                    { 29, "Gümüşhane" },
                    { 30, "Hakkari" },
                    { 31, "Hatay" },
                    { 32, "Isparta" },
                    { 33, "Mersin" },
                    { 34, "İstanbul" },
                    { 35, "İzmir" },
                    { 36, "Kars" },
                    { 37, "Kastamonu" },
                    { 38, "Kayseri" },
                    { 39, "Kırklareli" },
                    { 40, "Kırşehir" },
                    { 41, "Kocaeli" },
                    { 42, "Konya" },
                    { 43, "Kütahya" },
                    { 44, "Malatya" },
                    { 45, "Manisa" },
                    { 46, "Kahramanmaraş" },
                    { 47, "Mardin" },
                    { 48, "Muğla" },
                    { 49, "Muş" },
                    { 50, "Nevşehir" },
                    { 51, "Niğde" },
                    { 52, "Ordu" },
                    { 53, "Rize" },
                    { 54, "Sakarya" },
                    { 55, "Samsun" },
                    { 56, "Siirt" },
                    { 57, "Sinop" },
                    { 58, "Sivas" },
                    { 59, "Tekirdağ" },
                    { 60, "Tokat" },
                    { 61, "Trabzon" },
                    { 62, "Tunceli" },
                    { 63, "Şanlıurfa" },
                    { 64, "Uşak" },
                    { 65, "Van" },
                    { 66, "Yozgat" },
                    { 67, "Zonguldak" },
                    { 68, "Aksaray" },
                    { 69, "Bayburt" },
                    { 70, "Karaman" },
                    { 71, "Kırıkkale" },
                    { 72, "Batman" },
                    { 73, "Şırnak" },
                    { 74, "Bartın" },
                    { 75, "Ardahan" },
                    { 76, "Iğdır" },
                    { 77, "Yalova" },
                    { 78, "Karabük" },
                    { 79, "Kilis" },
                    { 80, "Osmaniye" },
                    { 81, "Düzce" }
                });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "Id", "ImageUrl", "Name", "Price", "Quantity", "Size", "Status" },
                values: new object[,]
                {
                    { 1, "BigMacMenu.jpg", "Big Mac Menu", 59.99m, 1, 0, 0 },
                    { 2, "DoubleBigMacMenu.jpg", "Double Big Mac Menu", 92.99m, 1, 0, 0 },
                    { 3, "DoubleMcEconomicalMenu.jpg", "Double McEconomical Menu", 51.99m, 1, 0, 0 },
                    { 4, "TripleMcEconomicalMenu.jpg", "Triple McEconomical Menu", 74.99m, 1, 0, 0 },
                    { 5, "BurgerwithMeatandCrispyChickenOfferMenu.jpg", "Burger with Meat and Crispy Chicken Offer Menu", 13.99m, 1, 0, 0 },
                    { 6, "DoubleBigTastyMenu.jpg", "Double Big Tasty Menu", 54.99m, 1, 0, 0 },
                    { 7, "GamerMenu.jpg", "Gamer Menu", 86.99m, 1, 0, 0 },
                    { 8, "LegendaryDuo(BigMac+McChicken).jpg", "Legendary Duo (Big Mac + McChicken) Menu", 71.99m, 1, 0, 0 },
                    { 9, "TripleBigMacOffer.jpg", "Triple Big Mac Offer", 65.99m, 1, 0, 0 },
                    { 10, "DoubleMeatballBurgerMenu.jpg", "Double Meatball Burger Menu", 53.99m, 1, 0, 0 },
                    { 11, "MeatballBurgerOfferMenu.jpg", "Meatball Burger Offer Menu", 51.99m, 1, 0, 0 },
                    { 12, "CrispyChickenOfferMenu.jpg", "Crispy Chicken Offer Menu", 60.99m, 1, 0, 0 },
                    { 13, "ClassicBigTastyMenu.jpg", "Classic Big Tasty Menu", 52.99m, 1, 0, 0 },
                    { 14, "ChickenBigTastyMenu.jpg", "Chicken Big Tasty Menu", 83.99m, 1, 0, 0 },
                    { 15, "NationalBurgerMenu.jpg", "National Burger Menu", 91.99m, 1, 0, 0 },
                    { 16, "DoubleSpicyChicken(Classic)Menu.jpg", "Double Spicy Chicken (Classic) Menu", 80.99m, 1, 0, 0 }
                });

            migrationBuilder.InsertData(
                table: "Silders",
                columns: new[] { "Id", "Description", "ImageUrl", "Number", "Title" },
                values: new object[,]
                {
                    { 1, "We offer hamburgers prepared with the freshest and highest quality ingredients in our restaurant. Our aim is to provide our guests with a delicious and healthy dining experience.", "slider1.jpg", 1, "Who We Are?" },
                    { 2, "Our mission is to provide the best service to our customers and exceed their expectations. We prioritize customer satisfaction with our hamburgers made with quality ingredients and our sincere service approach.", "slider2.jpg", 2, "Our Mission" },
                    { 3, "Our vision is to be an innovative and leading brand in the industry and ensure sustainable growth. We aim to win the admiration of our customers by constantly offering new flavors and experiences.", "silider3.jpg", 3, "Our Vision" }
                });

            migrationBuilder.InsertData(
                table: "Testimonials",
                columns: new[] { "Id", "Description", "ImageUrl", "Puan", "Title" },
                values: new object[,]
                {
                    { 1, "I had a fantastic experience at the restaurant. The burgers were delicious and the service was excellent.", "clientChef1.jpg", 5, "Great Experience!" },
                    { 2, "The burgers here are amazing! I loved every bite. Can't wait to come back again!", "clientChef2.jpg", 4, "Amazing Burgers!" },
                    { 3, "These burgers are hands down the best in town. The taste is unmatched!", "clientChef3.jpg", 5, "Best Burgers in Town!" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "ImageUrl", "Name", "Price", "Quantity", "Size", "Status" },
                values: new object[,]
                {
                    { 1, 1, "ClassicBigTasty.jpg", "Classic Big Tasty", 9.99m, 1, 0, 0 },
                    { 2, 1, "ChickenBigTasty.jpg", "Chicken Big Tasty", 10.99m, 1, 0, 0 },
                    { 3, 1, "DoubleSpicyChicken(Classic).jpg", "Double Spicy Chicken (Classic)", 12.99m, 1, 0, 0 },
                    { 4, 1, "NationalBurger.jpg", "National Burger", 8.99m, 1, 0, 0 },
                    { 5, 1, "SpicyChicken(Classic).jpg", "Spicy Chicken (Classic)", 7.99m, 1, 0, 0 },
                    { 6, 1, "McChicken.jpg", "McChicken", 6.99m, 1, 0, 0 },
                    { 7, 1, "CrispyChickenBurger.jpg", "Crispy Chicken Burger", 5.99m, 1, 0, 0 },
                    { 8, 1, "QuarterPounder.jpg", "Quarter Pounder", 8.49m, 1, 0, 0 },
                    { 9, 1, "DoubleBeefBurger.jpg", "Double Beef Burger", 11.99m, 1, 0, 0 },
                    { 10, 1, "BeefBurger.jpg", "Beef Burger", 7.49m, 1, 0, 0 },
                    { 11, 1, "DabaDabaBurger.jpg", "Daba Daba Burger", 10.49m, 1, 0, 0 },
                    { 12, 1, "DoubleBigMac.jpg", "Double Big Mac", 12.99m, 1, 0, 0 },
                    { 13, 1, "DoubleCheeseburger.jpg", "Double Cheeseburger", 9.49m, 1, 0, 0 },
                    { 14, 1, "DoubleMcChicken.jpg", "Double McChicken", 10.99m, 1, 0, 0 },
                    { 15, 1, "DoubleQuarterPounder.jpg", "Double Quarter Pounder", 11.49m, 1, 0, 0 },
                    { 16, 1, "BigMac.jpg", "Big Mac", 9.99m, 1, 0, 0 },
                    { 17, 1, "Hamburger.jpg", "Hamburger", 5.99m, 1, 0, 0 },
                    { 18, 1, "Cheeseburger.jpg", "Cheeseburger", 6.49m, 1, 0, 0 },
                    { 19, 2, "ForestFruitMuffin.jpg", "Forest Fruit Muffin", 3.79m, 1, 0, 0 },
                    { 20, 2, "StrawberryFilledWhiteChocolateDonut.jpg", "Strawberry Filled White Chocolate Donut", 4.29m, 1, 0, 0 },
                    { 21, 2, "StrawberryWhiteChocolateDecoratedDonut.jpg", "Strawberry White Chocolate Decorated Donut", 4.49m, 1, 0, 0 },
                    { 22, 2, "ChocolateCake.jpg", "Chocolate Cake", 6.99m, 1, 0, 0 },
                    { 23, 2, "HazelnutCreamFilledCocoaDonut.jpg", "Hazelnut Cream Filled Cocoa Donut", 3.99m, 1, 0, 0 },
                    { 24, 2, "RaspberryMuffin.jpg", "Raspberry Muffin", 3.79m, 1, 0, 0 },
                    { 25, 2, "RaspberryCheesecake.jpg", "Raspberry Cheesecake", 5.99m, 1, 0, 0 },
                    { 26, 2, "Brownie.jpg", "Brownie", 4.49m, 1, 0, 0 },
                    { 27, 2, "ChocolateMuffin.jpg", "Chocolate Muffin", 3.79m, 1, 0, 0 },
                    { 28, 2, "BlueberryCheesecake.jpg", "Blueberry Cheesecake", 5.99m, 1, 0, 0 },
                    { 29, 2, "CarrotCake.jpg", "Carrot Cake", 4.99m, 1, 0, 0 },
                    { 30, 2, "HazelnutCookie.jpg", "Hazelnut Cookie", 2.49m, 1, 0, 0 },
                    { 31, 2, "RaspberryChocolateCake.jpg", "Raspberry Chocolate Cake", 6.99m, 1, 0, 0 },
                    { 32, 2, "LemonCheesecake.jpg", "Lemon Cheesecake", 5.99m, 1, 0, 0 },
                    { 33, 2, "Macaron.jpg", "Macaron", 2.99m, 1, 0, 0 },
                    { 34, 2, "TripleChocolateCookie.jpg", "Triple Chocolate Cookie", 2.99m, 1, 0, 0 },
                    { 35, 2, "SenSebastianCheesecake.jpg", "SenSebastian Cheesecake", 6.49m, 1, 0, 0 },
                    { 36, 2, "RedVelvetCake.jpg", "Red Velvet Cake", 6.99m, 1, 0, 0 },
                    { 37, 2, "Tiramisu.jpg", "Tiramisu", 5.49m, 1, 0, 0 },
                    { 38, 3, "Ketchup(Packet).jpg", "Ketchup (Packet)", 0.99m, 1, 0, 0 },
                    { 39, 3, "Mayonnaise(Packet).jpg", "Mayonnaise (Packet)", 0.99m, 1, 0, 0 },
                    { 40, 3, "GarlicMayonnaise(Packet).jpg", "Garlic Mayonnaise (Packet)", 1.29m, 1, 0, 0 },
                    { 41, 3, "HotSauce(Packet).jpg", "Hot Sauce (Packet)", 1.29m, 1, 0, 0 },
                    { 42, 3, "BarbecueSauce.jpg", "Barbecue Sauce", 2.49m, 1, 0, 0 },
                    { 43, 3, "MustardSauce.jpg", "Mustard Sauce", 1.99m, 1, 0, 0 },
                    { 44, 3, "RanchSauce.jpg", "Ranch Sauce", 2.29m, 1, 0, 0 },
                    { 45, 3, "BuffaloSauce.jpg", "Buffalo Sauce", 2.99m, 1, 0, 0 },
                    { 46, 4, "LargeFrenchFries.jpg", "Large French Fries", 4.99m, 1, 3, 0 },
                    { 47, 4, "MediumFrenchFries.jpg", "Medium French Fries", 3.99m, 1, 2, 0 },
                    { 48, 4, "SmallFrenchFries.jpg", "Small French Fries", 2.99m, 1, 1, 0 },
                    { 49, 4, "CrispyOnions(8-piece).jpg", "Crispy Onions (8-piece)", 5.99m, 1, 0, 0 },
                    { 50, 4, "CrispyOnions(12-piece).jpg", "Crispy Onions (12-piece)", 7.99m, 1, 0, 0 },
                    { 51, 4, "CrispyOnions(16-piece).jpg", "Crispy Onions (16-piece)", 9.99m, 1, 0, 0 },
                    { 52, 4, "WaffleFries(Large).jpg", "Waffle Fries (Large)", 5.99m, 1, 3, 0 },
                    { 53, 4, "WaffleFries(Medium).jpg", "Waffle Fries (Medium)", 4.99m, 1, 2, 0 },
                    { 54, 4, "WaffleFries(Small).jpg", "Waffle Fries (Small)", 3.99m, 1, 1, 0 },
                    { 55, 4, "2-PieceCrispyTenders.jpg", "2-Piece Crispy Tenders", 6.99m, 1, 0, 0 },
                    { 56, 4, "4-PieceCrispyTenders.jpg", "4-Piece Crispy Tenders", 10.99m, 1, 0, 0 },
                    { 57, 5, "Mixology(Mango).jpg", "Mixology (Mango)", 15.99m, 1, 0, 0 },
                    { 58, 5, "Mixology(Strawberry).jpg", "Mixology (Strawberry)", 12.49m, 1, 0, 0 },
                    { 59, 5, "Mixology(Mint).jpg", "Mixology (Mint)", 18.79m, 1, 0, 0 },
                    { 60, 5, "Coca-ColaZeroSugar(Small).jpg", "Coca-Cola Zero Sugar (Small)", 11.99m, 1, 1, 0 },
                    { 61, 5, "Coca-ColaZeroSugar(Medium).jpg", "Coca-Cola Zero Sugar (Medium)", 13.29m, 1, 2, 0 },
                    { 62, 5, "Coca-ColaZeroSugar(Large).jpg", "Coca-Cola Zero Sugar (Large)", 14.99m, 1, 3, 0 },
                    { 63, 5, "Coca-Cola(Small).jpg", "Coca-Cola (Small)", 12.49m, 1, 1, 0 },
                    { 64, 5, "Coca-Cola(Medium).jpg", "Coca-Cola (Medium)", 11.79m, 1, 2, 0 },
                    { 65, 5, "Coca-Cola(Large).jpg", "Coca-Cola (Large)", 15.49m, 1, 3, 0 },
                    { 66, 5, "Fanta(Small).jpg", "Fanta (Small)", 10.99m, 1, 1, 0 },
                    { 67, 5, "Fanta(Medium).jpg", "Fanta (Medium)", 12.29m, 1, 2, 0 },
                    { 68, 5, "Fanta(Large).jpg", "Fanta (Large)", 13.49m, 1, 3, 0 },
                    { 69, 5, "Sprite(Small).jpg", "Sprite (Small)", 11.49m, 1, 1, 0 },
                    { 70, 5, "Sprite(Medium).jpg", "Sprite (Medium)", 14.99m, 1, 2, 0 },
                    { 71, 5, "Sprite(Large).jpg", "Sprite (Large)", 16.79m, 1, 3, 0 },
                    { 72, 5, "FuseTeaPeach(Small).jpg", "Fuse Tea Peach (Small)", 10.49m, 1, 1, 0 },
                    { 73, 5, "FuseTeaPeach(Medium).jpg", "Fuse Tea Peach (Medium)", 12.99m, 1, 2, 0 },
                    { 74, 5, "FuseTeaPeach(Large).jpg", "Fuse Tea Peach (Large)", 14.49m, 1, 3, 0 },
                    { 75, 5, "FuseTeaLemon(Small).jpg", "Fuse Tea Lemon (Small)", 11.29m, 1, 1, 0 },
                    { 76, 5, "FuseTeaLemon(Medium).jpg", "Fuse Tea Lemon (Medium)", 13.79m, 1, 2, 0 },
                    { 77, 5, "FuseTeaLemon(Large).jpg", "Fuse Tea Lemon (Large)", 15.99m, 1, 3, 0 },
                    { 78, 5, "StrawberryMilkshake(Small).jpg", "Strawberry Milkshake (Small)", 17.49m, 1, 1, 0 },
                    { 79, 5, "StrawberryMilkshake(Medium).jpg", "Strawberry Milkshake (Medium)", 0m, 1, 2, 0 },
                    { 80, 5, "StrawberryMilkshake(Large).jpg", "Strawberry Milkshake (Large)", 0m, 1, 3, 0 },
                    { 81, 5, "CoffeeMilkshake(Small).jpg", "Coffee Milkshake (Small)", 0m, 1, 1, 0 },
                    { 82, 5, "CoffeeMilkshake(Medium).jpg", "Coffee Milkshake (Medium)", 0m, 1, 2, 0 },
                    { 83, 5, "CoffeeMilkshake(Large).jpg", "Coffee Milkshake (Large)", 0m, 1, 3, 0 },
                    { 84, 5, "ChocolateMilkshake(Small).jpg", "Chocolate Milkshake (Small)", 0m, 1, 1, 0 },
                    { 85, 5, "ChocolateMilkshake(Medium).jpg", "Chocolate Milkshake (Medium)", 0m, 1, 2, 0 },
                    { 86, 5, "ChocolateMilkshake(Large).jpg", "Chocolate Milkshake (Large)", 0m, 1, 3, 0 },
                    { 87, 5, "Water.jpg", "Water", 2.49m, 1, 0, 0 },
                    { 88, 5, "Ayran.jpg", "Ayran", 1.99m, 1, 0, 0 }
                });

            migrationBuilder.InsertData(
                table: "MenuProduct",
                columns: new[] { "Id", "MenuId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 6, 2 },
                    { 2, 1, 7, 2 },
                    { 3, 1, 50, 2 },
                    { 4, 2, 6, 2 },
                    { 5, 2, 6, 2 },
                    { 6, 2, 7, 2 },
                    { 7, 2, 50, 2 },
                    { 8, 3, 9, 2 },
                    { 9, 3, 9, 2 },
                    { 10, 3, 7, 2 },
                    { 11, 3, 7, 2 },
                    { 12, 3, 50, 2 },
                    { 13, 3, 50, 2 },
                    { 14, 4, 11, 2 },
                    { 15, 4, 11, 2 },
                    { 16, 4, 8, 2 },
                    { 17, 4, 7, 2 },
                    { 18, 4, 7, 2 },
                    { 19, 4, 50, 2 },
                    { 20, 4, 50, 2 },
                    { 21, 5, 11, 2 },
                    { 22, 5, 11, 2 },
                    { 23, 5, 12, 2 },
                    { 24, 5, 12, 2 },
                    { 25, 5, 7, 2 },
                    { 26, 5, 13, 2 },
                    { 27, 5, 13, 2 },
                    { 28, 5, 50, 2 },
                    { 29, 5, 50, 2 },
                    { 30, 6, 3, 2 },
                    { 31, 6, 4, 2 },
                    { 32, 6, 7, 2 },
                    { 33, 6, 50, 2 },
                    { 34, 7, 6, 1 },
                    { 35, 7, 7, 1 },
                    { 36, 7, 14, 1 },
                    { 37, 7, 50, 1 },
                    { 38, 8, 6, 1 },
                    { 39, 8, 8, 1 },
                    { 40, 8, 7, 1 },
                    { 41, 8, 50, 1 },
                    { 42, 9, 6, 3 },
                    { 43, 9, 7, 1 },
                    { 44, 9, 50, 1 },
                    { 45, 10, 15, 2 },
                    { 46, 10, 7, 1 },
                    { 47, 10, 50, 1 },
                    { 48, 11, 11, 4 },
                    { 49, 11, 7, 1 },
                    { 50, 11, 13, 2 },
                    { 51, 11, 50, 2 },
                    { 52, 12, 12, 4 },
                    { 53, 12, 7, 1 },
                    { 54, 12, 13, 2 },
                    { 55, 12, 50, 2 },
                    { 56, 13, 3, 1 },
                    { 57, 13, 7, 1 },
                    { 58, 13, 50, 1 },
                    { 59, 14, 4, 1 },
                    { 60, 14, 7, 1 },
                    { 61, 14, 50, 1 },
                    { 62, 15, 16, 1 },
                    { 63, 15, 7, 1 },
                    { 64, 15, 50, 1 },
                    { 65, 16, 17, 1 },
                    { 66, 16, 7, 1 },
                    { 67, 16, 50, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CityId",
                table: "Addresses",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_UserId",
                table: "Addresses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_AddressId",
                table: "Contacts",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuProduct_MenuId",
                table: "MenuProduct",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuProduct_ProductId",
                table: "MenuProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_MenuId",
                table: "OrderDetails",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Abouts");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "MenuProduct");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Silders");

            migrationBuilder.DropTable(
                name: "Testimonials");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
