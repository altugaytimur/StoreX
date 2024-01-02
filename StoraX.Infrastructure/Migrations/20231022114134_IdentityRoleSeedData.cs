using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StoreX.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class IdentityRoleSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7a3d2230-19cf-45d7-a558-8ab298f5934e", null, "Admin", "ADMIN" },
                    { "acfb4789-b4e1-4666-8b01-bc5f5b7e344d", null, "Editor", "EDITOR" },
                    { "eb825a42-364c-4cfb-a7bc-347790acf907", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7a3d2230-19cf-45d7-a558-8ab298f5934e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "acfb4789-b4e1-4666-8b01-bc5f5b7e344d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eb825a42-364c-4cfb-a7bc-347790acf907");
        }
    }
}
