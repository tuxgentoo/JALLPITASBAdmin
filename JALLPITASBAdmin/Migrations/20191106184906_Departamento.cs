using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace JALLPITASBAdmin.Migrations
{
    public partial class Departamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Carpeta",
                table: "Carpeta");

            migrationBuilder.RenameTable(
                name: "Carpeta",
                newName: "Carpetas");

            migrationBuilder.AddColumn<int>(
                name: "DepartamentoId",
                table: "Carpetas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Carpetas",
                table: "Carpetas",
                column: "CarpetaId");

            migrationBuilder.CreateTable(
                name: "Departamentos",
                columns: table => new
                {
                    DepartamentoId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Nombre = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamentos", x => x.DepartamentoId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carpetas_DepartamentoId",
                table: "Carpetas",
                column: "DepartamentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carpetas_Departamentos_DepartamentoId",
                table: "Carpetas",
                column: "DepartamentoId",
                principalTable: "Departamentos",
                principalColumn: "DepartamentoId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carpetas_Departamentos_DepartamentoId",
                table: "Carpetas");

            migrationBuilder.DropTable(
                name: "Departamentos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Carpetas",
                table: "Carpetas");

            migrationBuilder.DropIndex(
                name: "IX_Carpetas_DepartamentoId",
                table: "Carpetas");

            migrationBuilder.DropColumn(
                name: "DepartamentoId",
                table: "Carpetas");

            migrationBuilder.RenameTable(
                name: "Carpetas",
                newName: "Carpeta");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Carpeta",
                table: "Carpeta",
                column: "CarpetaId");
        }
    }
}
