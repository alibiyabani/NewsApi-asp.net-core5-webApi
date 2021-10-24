using Microsoft.EntityFrameworkCore.Migrations;

namespace NewsApi.DataLayer.Migrations
{
    public partial class addadmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "Password", "UserName", "UserRole" },
                values: new object[] { -1, "alibiyabani63@gmail.com", "E1-0A-DC-39-49-BA-59-AB-BE-56-E0-57-F2-0F-88-3E", "alibiyabani63@gmail.com", "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -1);
        }
    }
}
