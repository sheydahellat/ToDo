using Microsoft.EntityFrameworkCore.Migrations;

namespace TodoApi.Migrations
{
    public partial class bookIdAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookShelves_shelves_Id",
                table: "BookShelves");

            migrationBuilder.DropForeignKey(
                name: "FK_shelves_UserEntities_Id",
                table: "shelves");

            migrationBuilder.AlterColumn<string>(
                name: "OwnerId",
                table: "shelves",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BookId",
                table: "BookShelves",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_shelves_OwnerId",
                table: "shelves",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_BookShelves_BookId",
                table: "BookShelves",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookShelves_shelves_BookId",
                table: "BookShelves",
                column: "BookId",
                principalTable: "shelves",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_shelves_UserEntities_OwnerId",
                table: "shelves",
                column: "OwnerId",
                principalTable: "UserEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookShelves_shelves_BookId",
                table: "BookShelves");

            migrationBuilder.DropForeignKey(
                name: "FK_shelves_UserEntities_OwnerId",
                table: "shelves");

            migrationBuilder.DropIndex(
                name: "IX_shelves_OwnerId",
                table: "shelves");

            migrationBuilder.DropIndex(
                name: "IX_BookShelves_BookId",
                table: "BookShelves");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "BookShelves");

            migrationBuilder.AlterColumn<string>(
                name: "OwnerId",
                table: "shelves",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BookShelves_shelves_Id",
                table: "BookShelves",
                column: "Id",
                principalTable: "shelves",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_shelves_UserEntities_Id",
                table: "shelves",
                column: "Id",
                principalTable: "UserEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
