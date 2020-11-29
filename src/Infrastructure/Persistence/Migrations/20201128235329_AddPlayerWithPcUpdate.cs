using Microsoft.EntityFrameworkCore.Migrations;

namespace ArcadiaStats.Infrastructure.Persistence.Migrations
{
    public partial class AddPlayerWithPcUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Class",
                table: "PlayerCharacters",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Class",
                table: "PlayerCharacters");
        }
    }
}
