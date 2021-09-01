using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APILocadoraCRUD.Migrations
{
    public partial class InicialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    IdCliente = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    CPF = table.Column<string>(type: "TEXT", maxLength: 11, nullable: false),
                    Telefone = table.Column<string>(type: "TEXT", maxLength: 11, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Situacao = table.Column<int>(type: "INTEGER", nullable: false),
                    Ativo = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.IdCliente);
                });

            migrationBuilder.CreateTable(
                name: "Generos",
                columns: table => new
                {
                    IdGenero = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    DataDeCriacao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Ativo = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generos", x => x.IdGenero);
                });

            migrationBuilder.CreateTable(
                name: "Filmes",
                columns: table => new
                {
                    IdFilme = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    DataDeCriacao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Ativo = table.Column<bool>(type: "INTEGER", nullable: false),
                    IdGenero = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filmes", x => x.IdFilme);
                    table.ForeignKey(
                        name: "FK_Filmes_Generos_IdGenero",
                        column: x => x.IdGenero,
                        principalTable: "Generos",
                        principalColumn: "IdGenero",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Locacaos",
                columns: table => new
                {
                    IdCliente = table.Column<int>(type: "INTEGER", nullable: false),
                    IdFilme = table.Column<int>(type: "INTEGER", nullable: false),
                    IdLocacao = table.Column<int>(type: "INTEGER", nullable: false),
                    DataDaLocacao = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locacaos", x => new { x.IdCliente, x.IdFilme });
                    table.ForeignKey(
                        name: "FK_Locacaos_Clientes_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Clientes",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Locacaos_Filmes_IdFilme",
                        column: x => x.IdFilme,
                        principalTable: "Filmes",
                        principalColumn: "IdFilme",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Filmes_IdGenero",
                table: "Filmes",
                column: "IdGenero");

            migrationBuilder.CreateIndex(
                name: "IX_Locacaos_IdFilme",
                table: "Locacaos",
                column: "IdFilme");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Locacaos");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Filmes");

            migrationBuilder.DropTable(
                name: "Generos");
        }
    }
}
