using Microsoft.EntityFrameworkCore.Migrations;

namespace Kulinarna.Data.Migrations
{
    public partial class RecipiesTableModified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "AvgRating",
                table: "Recipes",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvgRating",
                table: "Recipes");
        }
    }
}
