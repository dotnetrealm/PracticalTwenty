using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PracticalTwenty.Data.Migrations
{
    /// <inheritdoc />
    public partial class addUserSeeder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Firstname", "LastName", "Password" },
                values: new object[,]
                {
                    { 1, "bhavin@gmail.com", "Bhavin", "Kareliya", "123123" },
                    { 2, "jil@gmail.com", "Jil", "Patel", "123123" },
                    { 3, "vipul@gmail.com", "Vipul", "Kumar", "123123" },
                    { 4, "abhi@gmail.com", "Abhi", "Dasadiya", "123123" },
                    { 5, "jay@gmail.com", "Jay", "Gohel", "123123" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
