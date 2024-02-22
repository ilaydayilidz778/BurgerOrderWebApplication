using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MvcOOPHamburgerProject.Migrations
{
    /// <inheritdoc />
    public partial class Second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 33);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "ImageUrl", "Name", "Price", "Quantity", "Size", "Status" },
                values: new object[,]
                {
                    { 24, 2, "RaspberryMuffin.jpg", "Raspberry Muffin", 3.79m, 1, 0, 0 },
                    { 25, 2, "RaspberryCheesecake.jpg", "Raspberry Cheesecake", 5.99m, 1, 0, 0 },
                    { 28, 2, "BlueberryCheesecake.jpg", "Blueberry Cheesecake", 5.99m, 1, 0, 0 },
                    { 32, 2, "LemonCheesecake.jpg", "Lemon Cheesecake", 5.99m, 1, 0, 0 },
                    { 33, 2, "Macaron.jpg", "Macaron", 2.99m, 1, 0, 0 }
                });
        }
    }
}
