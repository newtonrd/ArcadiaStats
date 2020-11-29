using Microsoft.EntityFrameworkCore.Migrations;

namespace ArcadiaStats.Infrastructure.Persistence.Migrations
{
    public partial class AddPlayerDbSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlayerId",
                table: "PlayerCharacters",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerCharacters_PlayerId",
                table: "PlayerCharacters",
                column: "PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerCharacters_Players_PlayerId",
                table: "PlayerCharacters",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerCharacters_Players_PlayerId",
                table: "PlayerCharacters");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropIndex(
                name: "IX_PlayerCharacters_PlayerId",
                table: "PlayerCharacters");

            migrationBuilder.DropColumn(
                name: "PlayerId",
                table: "PlayerCharacters");
        }
    }
}
