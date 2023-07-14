using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PracticalTwenty.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddApplicationLogs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Area = table.Column<string>(type: "varchar(50)", nullable: true),
                    ControllerName = table.Column<string>(type: "varchar(50)", nullable: false),
                    ActionName = table.Column<string>(type: "varchar(50)", nullable: false),
                    RoleId = table.Column<string>(type: "varchar(2)", nullable: true),
                    LangId = table.Column<string>(type: "varchar(2)", nullable: true),
                    IpAddress = table.Column<string>(type: "varchar(50)", nullable: true),
                    IsFirstLogin = table.Column<string>(type: "char(1)", nullable: true),
                    LoggedInAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LoggedOutAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LoginStatus = table.Column<string>(type: "char(1)", nullable: true),
                    PageAccessed = table.Column<string>(type: "varchar(500)", nullable: true),
                    SessionId = table.Column<string>(type: "varchar(50)", nullable: true),
                    UrlReferrer = table.Column<string>(type: "varchar(500)", nullable: true),
                    UserId = table.Column<string>(type: "varchar(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationLogs", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationLogs");
        }
    }
}
