using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace iot.Data.Migrations
{
    /// <inheritdoc />
    public partial class renameFieldMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ButtonStatus",
                table: "Items",
                newName: "ButtonState");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ButtonState",
                table: "Items",
                newName: "ButtonStatus");
        }
    }
}
