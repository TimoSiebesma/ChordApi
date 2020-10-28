using Microsoft.EntityFrameworkCore.Migrations;

namespace ChordApi.Migrations
{
    public partial class deletedGenre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Genre",
                table: "Songs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Genre",
                table: "Songs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
