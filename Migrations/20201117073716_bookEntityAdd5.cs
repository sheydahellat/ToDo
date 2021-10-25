using Microsoft.EntityFrameworkCore.Migrations;

namespace TodoApi.Migrations
{
    public partial class bookEntityAdd5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MyBookId",
                table: "BookShelves");

            migrationBuilder.AddColumn<string>(
                name: "BookId",
                table: "BookShelves",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookId",
                table: "BookShelves");

            migrationBuilder.AddColumn<string>(
                name: "MyBookId",
                table: "BookShelves",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
