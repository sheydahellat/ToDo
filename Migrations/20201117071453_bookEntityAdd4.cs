using Microsoft.EntityFrameworkCore.Migrations;

namespace TodoApi.Migrations
{
    public partial class bookEntityAdd4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookShelves_BookEntities_BookId",
                table: "BookShelves");

            migrationBuilder.DropIndex(
                name: "IX_BookShelves_BookId",
                table: "BookShelves");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "BookShelves");

            migrationBuilder.AddColumn<string>(
                name: "MyBookId",
                table: "BookShelves",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "bookEntityId",
                table: "BookShelves",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookShelves_bookEntityId",
                table: "BookShelves",
                column: "bookEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookShelves_BookEntities_bookEntityId",
                table: "BookShelves",
                column: "bookEntityId",
                principalTable: "BookEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookShelves_BookEntities_bookEntityId",
                table: "BookShelves");

            migrationBuilder.DropIndex(
                name: "IX_BookShelves_bookEntityId",
                table: "BookShelves");

            migrationBuilder.DropColumn(
                name: "MyBookId",
                table: "BookShelves");

            migrationBuilder.DropColumn(
                name: "bookEntityId",
                table: "BookShelves");

            migrationBuilder.AddColumn<string>(
                name: "BookId",
                table: "BookShelves",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookShelves_BookId",
                table: "BookShelves",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookShelves_BookEntities_BookId",
                table: "BookShelves",
                column: "BookId",
                principalTable: "BookEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
