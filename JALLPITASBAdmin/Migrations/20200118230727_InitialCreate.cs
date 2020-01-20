using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JALLPITASBAdmin.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RegistroVisita",
                columns: table => new
                {
                    RegistroVisitaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true),
                    Ci = table.Column<int>(nullable: false),
                    Celular = table.Column<int>(nullable: false),
                    TipoPersona = table.Column<int>(nullable: false),
                    DepartamentoId = table.Column<int>(nullable: false),
                    NombreProceso = table.Column<string>(nullable: true),
                    Observacion = table.Column<string>(nullable: true),
                    FechaVisita = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistroVisita", x => x.RegistroVisitaId);
                    table.ForeignKey(
                        name: "FK_RegistroVisita_Departamentos_DepartamentoId",
                        column: x => x.DepartamentoId,
                        principalTable: "Departamentos",
                        principalColumn: "DepartamentoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RegistroVisita_DepartamentoId",
                table: "RegistroVisita",
                column: "DepartamentoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegistroVisita");
        }
    }
}
