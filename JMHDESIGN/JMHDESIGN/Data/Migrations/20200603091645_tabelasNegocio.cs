using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JMHDESIGN.Data.Migrations
{
    public partial class tabelasNegocio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    IDcliente = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Contacto = table.Column<int>(nullable: false),
                    Morada = table.Column<string>(nullable: false),
                    CodPostal = table.Column<string>(nullable: false),
                    UserNameId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.IDcliente);
                });

            migrationBuilder.CreateTable(
                name: "Projetos",
                columns: table => new
                {
                    IDfunc = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: false),
                    Cargo = table.Column<string>(nullable: false),
                    Contacto = table.Column<int>(nullable: false),
                    Morada = table.Column<int>(nullable: false),
                    CodPostal = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projetos", x => x.IDfunc);
                });

            migrationBuilder.CreateTable(
                name: "Formularios",
                columns: table => new
                {
                    IDform = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Assunto = table.Column<string>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    Descricao = table.Column<string>(nullable: false),
                    ClienteFK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Formularios", x => x.IDform);
                    table.ForeignKey(
                        name: "FK_Formularios_Clientes_ClienteFK",
                        column: x => x.ClienteFK,
                        principalTable: "Clientes",
                        principalColumn: "IDcliente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    IDproj = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    Categoria = table.Column<string>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    Fotografia = table.Column<string>(nullable: true),
                    ClientesFK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.IDproj);
                    table.ForeignKey(
                        name: "FK_Funcionarios_Clientes_ClientesFK",
                        column: x => x.ClientesFK,
                        principalTable: "Clientes",
                        principalColumn: "IDcliente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjetosFuncionarios",
                columns: table => new
                {
                    IDprojfunc = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDprojFK = table.Column<int>(nullable: false),
                    IDfuncFK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjetosFuncionarios", x => x.IDprojfunc);
                    table.ForeignKey(
                        name: "FK_ProjetosFuncionarios_Projetos_IDfuncFK",
                        column: x => x.IDfuncFK,
                        principalTable: "Projetos",
                        principalColumn: "IDfunc",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjetosFuncionarios_Funcionarios_IDprojFK",
                        column: x => x.IDprojFK,
                        principalTable: "Funcionarios",
                        principalColumn: "IDproj",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Formularios_ClienteFK",
                table: "Formularios",
                column: "ClienteFK");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_ClientesFK",
                table: "Funcionarios",
                column: "ClientesFK");

            migrationBuilder.CreateIndex(
                name: "IX_ProjetosFuncionarios_IDfuncFK",
                table: "ProjetosFuncionarios",
                column: "IDfuncFK");

            migrationBuilder.CreateIndex(
                name: "IX_ProjetosFuncionarios_IDprojFK",
                table: "ProjetosFuncionarios",
                column: "IDprojFK");

            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Formularios");

            migrationBuilder.DropTable(
                name: "ProjetosFuncionarios");

            migrationBuilder.DropTable(
                name: "Projetos");

            migrationBuilder.DropTable(
                name: "Funcionarios");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
