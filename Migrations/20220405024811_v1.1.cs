using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class v11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Venda_Cliente_ClienteId",
                table: "Venda");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Venda",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "Categoria",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Venda_Cliente_ClienteId",
                table: "Venda",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Venda_Cliente_ClienteId",
                table: "Venda");

            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Categoria");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Venda",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Venda_Cliente_ClienteId",
                table: "Venda",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
