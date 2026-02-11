using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Parcial1_API.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alumno",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Matricula = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    Carrera = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alumno", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Alumno",
                columns: new[] { "ID", "Carrera", "Edad", "Matricula", "Nombre" },
                values: new object[,]
                {
                    { 1, "Ingeniería", 20, 2024001, "Ana López" },
                    { 2, "Derecho", 22, 2024002, "Luis Pérez" },
                    { 3, "Medicina", 21, 2024003, "María Gómez" },
                    { 4, "Arquitectura", 23, 2024004, "Carlos Ruiz" },
                    { 5, "Psicología", 19, 2024005, "Sofía Torres" },
                    { 6, "Contaduría", 24, 2024006, "Jorge Díaz" },
                    { 7, "Informática", 20, 2024007, "Valeria Ramos" },
                    { 8, "Administración", 22, 2024008, "Miguel Sánchez" },
                    { 9, "Biología", 21, 2024009, "Lucía Navarro" },
                    { 10, "Economía", 23, 2024010, "Daniel Herrera" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alumno");
        }
    }
}
