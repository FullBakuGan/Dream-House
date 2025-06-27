using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dream_House.Migrations
{
    /// <inheritdoc />
    public partial class atr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "role",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "role",
                newName: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "name",
                table: "role",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "role",
                newName: "Id");
        }
    }
}
