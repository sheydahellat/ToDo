using Microsoft.EntityFrameworkCore.Migrations;

namespace TodoApi.Migrations
{
    public partial class bookEntityAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookShelves_shelves_BookId",
                table: "BookShelves");

            migrationBuilder.AlterColumn<string>(
                name: "ShelfId",
                table: "BookShelves",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookShelves_ShelfId",
                table: "BookShelves",
                column: "ShelfId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookShelves_BookEntities_BookId",
                table: "BookShelves",
                column: "BookId",
                principalTable: "BookEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BookShelves_shelves_ShelfId",
                table: "BookShelves",
                column: "ShelfId",
                principalTable: "shelves",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookShelves_BookEntities_BookId",
                table: "BookShelves");

            migrationBuilder.DropForeignKey(
                name: "FK_BookShelves_shelves_ShelfId",
                table: "BookShelves");

            migrationBuilder.DropIndex(
                name: "IX_BookShelves_ShelfId",
                table: "BookShelves");

            migrationBuilder.AlterColumn<string>(
                name: "ShelfId",
                table: "BookShelves",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BookShelves_shelves_BookId",
                table: "BookShelves",
                column: "BookId",
                principalTable: "shelves",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
