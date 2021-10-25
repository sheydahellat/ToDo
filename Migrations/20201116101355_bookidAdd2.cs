using Microsoft.EntityFrameworkCore.Migrations;

namespace TodoApi.Migrations
{
    public partial class bookidAdd2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_shelves_UserEntities_OwnerId",
                table: "shelves");

            migrationBuilder.DropIndex(
                name: "IX_shelves_OwnerId",
                table: "shelves");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "shelves",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OwnerId",
                table: "shelves",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BookId",
                table: "BookEntities",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_shelves_UserId",
                table: "shelves",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_shelves_UserEntities_UserId",
                table: "shelves",
                column: "UserId",
                principalTable: "UserEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_shelves_UserEntities_UserId",
                table: "shelves");

            migrationBuilder.DropIndex(
                name: "IX_shelves_UserId",
                table: "shelves");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "BookEntities");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "shelves",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OwnerId",
                table: "shelves",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_shelves_OwnerId",
                table: "shelves",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_shelves_UserEntities_OwnerId",
                table: "shelves",
                column: "OwnerId",
                principalTable: "UserEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
