using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductsApi.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class alternateKeyRemoving : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Products_Name",
                table: "Products");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddUniqueConstraint(
                name: "AK_Products_Name",
                table: "Products",
                column: "Name");
        }
    }
}
