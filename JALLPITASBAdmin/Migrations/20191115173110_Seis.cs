using Microsoft.EntityFrameworkCore.Migrations;

namespace JALLPITASBAdmin.Migrations
{
    public partial class Seis : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carpetas_Provincias_ProvinciaId",
                table: "Carpetas");

            migrationBuilder.DropIndex(
                name: "IX_Carpetas_ProvinciaId",
                table: "Carpetas");

            migrationBuilder.DropColumn(
                name: "ProvinciaId",
                table: "Carpetas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProvinciaId",
                table: "Carpetas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Carpetas_ProvinciaId",
                table: "Carpetas",
                column: "ProvinciaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carpetas_Provincias_ProvinciaId",
                table: "Carpetas",
                column: "ProvinciaId",
                principalTable: "Provincias",
                principalColumn: "ProvinciaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
