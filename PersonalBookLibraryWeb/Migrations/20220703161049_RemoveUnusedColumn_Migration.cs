using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalBookLibraryWeb.Migrations
{
    public partial class RemoveUnusedColumn_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LibSectionId",
                table: "Books");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LibSectionId",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
