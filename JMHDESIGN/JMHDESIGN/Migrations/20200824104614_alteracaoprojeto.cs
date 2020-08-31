using Microsoft.EntityFrameworkCore.Migrations;

namespace JMHDESIGN.Migrations
{
    public partial class alteracaoprojeto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.DropTable(
                name: "ProjetosClientes");

            migrationBuilder.AddColumn<int>(
                name: "ClienteFK",
                table: "Projetos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c",
                column: "ConcurrencyStamp",
                value: "5ab76549-5684-4992-99e2-8eb51106d64c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f",
                column: "ConcurrencyStamp",
                value: "5ae2834d-bb06-4778-ba2e-1dd621ddd763");

            migrationBuilder.CreateIndex(
                name: "IX_Projetos_ClienteFK",
                table: "Projetos",
                column: "ClienteFK");

            migrationBuilder.AddForeignKey(
                name: "FK_Projetos_Clientes_ClienteFK",
                table: "Projetos",
                column: "ClienteFK",
                principalTable: "Clientes",
                principalColumn: "IDcliente",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projetos_Clientes_ClienteFK",
                table: "Projetos");

            migrationBuilder.DropIndex(
                name: "IX_Projetos_ClienteFK",
                table: "Projetos");

            migrationBuilder.DropColumn(
                name: "ClienteFK",
                table: "Projetos");

            migrationBuilder.AddColumn<int>(
                name: "ClientesIDcliente",
                table: "Projetos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProjetosClientes",
                columns: table => new
                {
                    IDprojcliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDclienteFK = table.Column<int>(type: "int", nullable: false),
                    IDproj1 = table.Column<int>(type: "int", nullable: true),
                    IDprojFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjetosClientes", x => x.IDprojcliente);
                    table.ForeignKey(
                        name: "FK_ProjetosClientes_Clientes_IDclienteFK",
                        column: x => x.IDclienteFK,
                        principalTable: "Clientes",
                        principalColumn: "IDcliente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjetosClientes_Projetos_IDproj1",
                        column: x => x.IDproj1,
                        principalTable: "Projetos",
                        principalColumn: "IDproj",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c",
                column: "ConcurrencyStamp",
                value: "877404f0-b1b2-4306-9911-08c95a29940d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f",
                column: "ConcurrencyStamp",
                value: "3dd4cbf6-99f0-4316-8ae3-7f9b7681944d");

            migrationBuilder.CreateIndex(
                name: "IX_Projetos_ClientesIDcliente",
                table: "Projetos",
                column: "ClientesIDcliente");

            migrationBuilder.CreateIndex(
                name: "IX_ProjetosClientes_IDclienteFK",
                table: "ProjetosClientes",
                column: "IDclienteFK");

            migrationBuilder.CreateIndex(
                name: "IX_ProjetosClientes_IDproj1",
                table: "ProjetosClientes",
                column: "IDproj1");

            migrationBuilder.AddForeignKey(
                name: "FK_Projetos_Clientes_ClientesIDcliente",
                table: "Projetos",
                column: "ClientesIDcliente",
                principalTable: "Clientes",
                principalColumn: "IDcliente",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
