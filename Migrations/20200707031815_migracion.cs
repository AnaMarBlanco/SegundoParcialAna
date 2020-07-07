using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SegundoPacialAna.Migrations
{
    public partial class migracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Proyectos",
                columns: table => new
                {
                    ProyectoId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Descripcion = table.Column<string>(nullable: true),
                    TiempoTotal = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proyectos", x => x.ProyectoId);
                });

            migrationBuilder.CreateTable(
                name: "Tipos",
                columns: table => new
                {
                    TipoId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TipoTarea = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipos", x => x.TipoId);
                });

            migrationBuilder.CreateTable(
                name: "TareasDetalle",
                columns: table => new
                {
                    TareaId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Requerimientos = table.Column<string>(nullable: true),
                    Tiempo = table.Column<int>(nullable: false),
                    TipoId = table.Column<int>(nullable: false),
                    TipoTarea = table.Column<string>(nullable: true),
                    ProyectoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TareasDetalle", x => x.TareaId);
                    table.ForeignKey(
                        name: "FK_TareasDetalle_Proyectos_ProyectoId",
                        column: x => x.ProyectoId,
                        principalTable: "Proyectos",
                        principalColumn: "ProyectoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Tipos",
                columns: new[] { "TipoId", "TipoTarea" },
                values: new object[] { 1, "Analisis" });

            migrationBuilder.InsertData(
                table: "Tipos",
                columns: new[] { "TipoId", "TipoTarea" },
                values: new object[] { 2, "Diseño" });

            migrationBuilder.InsertData(
                table: "Tipos",
                columns: new[] { "TipoId", "TipoTarea" },
                values: new object[] { 3, "Programación" });

            migrationBuilder.InsertData(
                table: "Tipos",
                columns: new[] { "TipoId", "TipoTarea" },
                values: new object[] { 4, "Prueba" });

            migrationBuilder.CreateIndex(
                name: "IX_TareasDetalle_ProyectoId",
                table: "TareasDetalle",
                column: "ProyectoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TareasDetalle");

            migrationBuilder.DropTable(
                name: "Tipos");

            migrationBuilder.DropTable(
                name: "Proyectos");
        }
    }
}
