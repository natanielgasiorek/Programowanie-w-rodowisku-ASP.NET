using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PrzychodniaFinal.Migrations
{
    public partial class UpdateWizyty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chorobies");

            migrationBuilder.DropTable(
                name: "Recepties");

            migrationBuilder.CreateTable(
                name: "Wizyties",
                columns: table => new
                {
                    ChorobyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PacjentID = table.Column<int>(type: "int", nullable: false),
                    PracownikID = table.Column<int>(type: "int", nullable: false),
                    PrzebiegChoroby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataWizyty = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wizyties", x => x.ChorobyID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Wizyties");

            migrationBuilder.CreateTable(
                name: "Recepties",
                columns: table => new
                {
                    IdChoroby = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataWystawienia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdRecepty = table.Column<int>(type: "int", nullable: false),
                    Lek = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PacjenciID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recepties", x => x.IdChoroby);
                    table.ForeignKey(
                        name: "FK_Recepties_Pacjencis_PacjenciID",
                        column: x => x.PacjenciID,
                        principalTable: "Pacjencis",
                        principalColumn: "PacjenciID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Chorobies",
                columns: table => new
                {
                    ChorobyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdChoroby = table.Column<int>(type: "int", nullable: true),
                    IdPacjenta = table.Column<int>(type: "int", nullable: false),
                    IdPracownikaNavigationLekarzeID = table.Column<int>(type: "int", nullable: true),
                    PacjenciID = table.Column<int>(type: "int", nullable: false),
                    PracownicyID = table.Column<int>(type: "int", nullable: false),
                    PrzebiegChoroby = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chorobies", x => x.ChorobyID);
                    table.ForeignKey(
                        name: "FK_Chorobies_Lekarzes_IdPracownikaNavigationLekarzeID",
                        column: x => x.IdPracownikaNavigationLekarzeID,
                        principalTable: "Lekarzes",
                        principalColumn: "LekarzeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Chorobies_Pacjencis_PacjenciID",
                        column: x => x.PacjenciID,
                        principalTable: "Pacjencis",
                        principalColumn: "PacjenciID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Chorobies_Recepties_IdChoroby",
                        column: x => x.IdChoroby,
                        principalTable: "Recepties",
                        principalColumn: "IdChoroby",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chorobies_IdChoroby",
                table: "Chorobies",
                column: "IdChoroby");

            migrationBuilder.CreateIndex(
                name: "IX_Chorobies_IdPracownikaNavigationLekarzeID",
                table: "Chorobies",
                column: "IdPracownikaNavigationLekarzeID");

            migrationBuilder.CreateIndex(
                name: "IX_Chorobies_PacjenciID",
                table: "Chorobies",
                column: "PacjenciID");

            migrationBuilder.CreateIndex(
                name: "IX_Recepties_PacjenciID",
                table: "Recepties",
                column: "PacjenciID");
        }
    }
}
