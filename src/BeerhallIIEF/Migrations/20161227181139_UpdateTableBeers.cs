using Microsoft.EntityFrameworkCore.Migrations;

namespace BeerhallIIEF.Migrations
{
    public partial class UpdateTableBeers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Beers",
                maxLength: 100,
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Beers",
                nullable: true);
        }
    }
}
