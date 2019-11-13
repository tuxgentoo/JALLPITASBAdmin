using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace JALLPITASBAdmin.Migrations
{
    public partial class Provincia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MunicipioId",
                table: "Carpetas",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProvinciaId",
                table: "Carpetas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Provincias",
                columns: table => new
                {
                    ProvinciaId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Nombre = table.Column<string>(nullable: false),
                    DepartamentoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provincias", x => x.ProvinciaId);
                    table.ForeignKey(
                        name: "FK_Provincias_Departamentos_DepartamentoId",
                        column: x => x.DepartamentoId,
                        principalTable: "Departamentos",
                        principalColumn: "DepartamentoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Municipios",
                columns: table => new
                {
                    MunicipioId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Nombre = table.Column<string>(nullable: false),
                    ProvinciaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipios", x => x.MunicipioId);
                    table.ForeignKey(
                        name: "FK_Municipios_Provincias_ProvinciaId",
                        column: x => x.ProvinciaId,
                        principalTable: "Provincias",
                        principalColumn: "ProvinciaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carpetas_MunicipioId",
                table: "Carpetas",
                column: "MunicipioId");

            migrationBuilder.CreateIndex(
                name: "IX_Carpetas_ProvinciaId",
                table: "Carpetas",
                column: "ProvinciaId");

            migrationBuilder.CreateIndex(
                name: "IX_Municipios_ProvinciaId",
                table: "Municipios",
                column: "ProvinciaId");

            migrationBuilder.CreateIndex(
                name: "IX_Provincias_DepartamentoId",
                table: "Provincias",
                column: "DepartamentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carpetas_Municipios_MunicipioId",
                table: "Carpetas",
                column: "MunicipioId",
                principalTable: "Municipios",
                principalColumn: "MunicipioId",
                onDelete: ReferentialAction.Restrict);

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
                name: "FK_Carpetas_Municipios_MunicipioId",
                table: "Carpetas");

            migrationBuilder.DropForeignKey(
                name: "FK_Carpetas_Provincias_ProvinciaId",
                table: "Carpetas");

            migrationBuilder.DropTable(
                name: "Municipios");

            migrationBuilder.DropTable(
                name: "Provincias");

            migrationBuilder.DropIndex(
                name: "IX_Carpetas_MunicipioId",
                table: "Carpetas");

            migrationBuilder.DropIndex(
                name: "IX_Carpetas_ProvinciaId",
                table: "Carpetas");

            migrationBuilder.DropColumn(
                name: "MunicipioId",
                table: "Carpetas");

            migrationBuilder.DropColumn(
                name: "ProvinciaId",
                table: "Carpetas");
        }
    }
}
