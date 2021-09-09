using Microsoft.EntityFrameworkCore.Migrations;

namespace Kulinarna.Data.Migrations
{
    public partial class AuthorNameAddedToRecipe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AuthorName",
                table: "Recipes",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuthorName",
                table: "Recipes");
        }
    }
}
