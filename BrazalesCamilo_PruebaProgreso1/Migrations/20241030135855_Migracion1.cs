using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BrazalesCamilo_PruebaProgreso1.Migrations
{
    /// <inheritdoc />
    public partial class Migracion1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Celular",
                columns: table => new
                {
                    Id_celular = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CelularNombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    anio = table.Column<int>(type: "int", nullable: false),
                    precio = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Celular", x => x.Id_celular);
                });

            migrationBuilder.CreateTable(
                name: "CBrazales",
                columns: table => new
                {
                    Id_usuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Tiene_trabajo = table.Column<bool>(type: "bit", nullable: false),
                    Ingreso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Salario = table.Column<double>(type: "float", nullable: false),
                    Id_celular = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CBrazales", x => x.Id_usuario);
                    table.ForeignKey(
                        name: "FK_CBrazales_Celular_Id_celular",
                        column: x => x.Id_celular,
                        principalTable: "Celular",
                        principalColumn: "Id_celular",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CBrazales_Id_celular",
                table: "CBrazales",
                column: "Id_celular");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CBrazales");

            migrationBuilder.DropTable(
                name: "Celular");
        }
    }
}
