using Microsoft.EntityFrameworkCore.Migrations;

namespace JALLPITASBAdmin.Migrations
{
    public partial class Ocho : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carpetas_Provincias_ProvinciaId",
                table: "Carpetas");

            migrationBuilder.AlterColumn<int>(
                name: "ProvinciaId",
                table: "Carpetas",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Carpetas_Provincias_ProvinciaId",
                table: "Carpetas",
                column: "ProvinciaId",
                principalTable: "Provincias",
                principalColumn: "ProvinciaId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carpetas_Provincias_ProvinciaId",
                table: "Carpetas");

            migrationBuilder.AlterColumn<int>(
                name: "ProvinciaId",
                table: "Carpetas",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Carpetas_Provincias_ProvinciaId",
                table: "Carpetas",
                column: "ProvinciaId",
                principalTable: "Provincias",
                principalColumn: "ProvinciaId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
