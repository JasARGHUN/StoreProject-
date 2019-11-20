using Microsoft.EntityFrameworkCore.Migrations;

namespace StoreProject.Migrations
{
    public partial class UpDB1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartLine_Products_ProductID",
                table: "CartLine");

            migrationBuilder.RenameColumn(
                name: "ProductID",
                table: "CartLine",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_CartLine_ProductID",
                table: "CartLine",
                newName: "IX_CartLine_ProductId");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "CartLine",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CartLine_Products_ProductId",
                table: "CartLine",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartLine_Products_ProductId",
                table: "CartLine");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "CartLine",
                newName: "ProductID");

            migrationBuilder.RenameIndex(
                name: "IX_CartLine_ProductId",
                table: "CartLine",
                newName: "IX_CartLine_ProductID");

            migrationBuilder.AlterColumn<int>(
                name: "ProductID",
                table: "CartLine",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_CartLine_Products_ProductID",
                table: "CartLine",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
