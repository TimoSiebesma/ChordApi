using Microsoft.EntityFrameworkCore.Migrations;

namespace ChordApi.Migrations
{
    public partial class updatedMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chords_Songs_SongId",
                table: "Chords");

            migrationBuilder.DropIndex(
                name: "IX_Chords_SongId",
                table: "Chords");

            migrationBuilder.DropColumn(
                name: "SongId",
                table: "Chords");

            migrationBuilder.CreateTable(
                name: "SongChord",
                columns: table => new
                {
                    SongId = table.Column<int>(nullable: false),
                    ChordId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SongChord", x => new { x.SongId, x.ChordId });
                    table.ForeignKey(
                        name: "FK_SongChord_Chords_ChordId",
                        column: x => x.ChordId,
                        principalTable: "Chords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SongChord_Songs_SongId",
                        column: x => x.SongId,
                        principalTable: "Songs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SongChord_ChordId",
                table: "SongChord",
                column: "ChordId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SongChord");

            migrationBuilder.AddColumn<int>(
                name: "SongId",
                table: "Chords",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Chords_SongId",
                table: "Chords",
                column: "SongId");

            migrationBuilder.AddForeignKey(
                name: "FK_Chords_Songs_SongId",
                table: "Chords",
                column: "SongId",
                principalTable: "Songs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
