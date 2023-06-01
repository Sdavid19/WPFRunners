using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Futoverseny.Migrations
{
    public partial class elso : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TavolsagModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Megnevezes = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TavolsagModel", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Versenyzok",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Rajtszam = table.Column<int>(type: "int", nullable: false),
                    Nev = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SzuletesiDatum = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Neme = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TavolsagId = table.Column<int>(type: "int", nullable: false),
                    Korosztaly = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Versenyzok", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Versenyzok_TavolsagModel_TavolsagId",
                        column: x => x.TavolsagId,
                        principalTable: "TavolsagModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "TavolsagModel",
                columns: new[] { "Id", "Megnevezes" },
                values: new object[,]
                {
                    { 1, "maraton" },
                    { 2, "félmaraton" },
                    { 3, "10km" },
                    { 4, "5km" },
                    { 5, "2km" }
                });

            migrationBuilder.InsertData(
                table: "Versenyzok",
                columns: new[] { "Id", "Korosztaly", "Neme", "Nev", "Rajtszam", "SzuletesiDatum", "TavolsagId" },
                values: new object[] { 1, "senior", "fiu", "Sanyi", 1, null, 3 });

            migrationBuilder.CreateIndex(
                name: "IX_TavolsagModel_Megnevezes",
                table: "TavolsagModel",
                column: "Megnevezes",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Versenyzok_Rajtszam",
                table: "Versenyzok",
                column: "Rajtszam",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Versenyzok_TavolsagId",
                table: "Versenyzok",
                column: "TavolsagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Versenyzok");

            migrationBuilder.DropTable(
                name: "TavolsagModel");
        }
    }
}
