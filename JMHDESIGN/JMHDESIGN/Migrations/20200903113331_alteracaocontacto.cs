using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JMHDESIGN.Migrations
{
    public partial class alteracaocontacto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_Clientes_ClienteFK",
                table: "Funcionarios");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjetosFuncionarios_Projetos_IDfuncFK",
                table: "ProjetosFuncionarios");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjetosFuncionarios_Funcionarios_IDprojFK",
                table: "ProjetosFuncionarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Projetos",
                table: "Projetos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Funcionarios",
                table: "Funcionarios");

            migrationBuilder.DropIndex(
                name: "IX_Funcionarios_ClienteFK",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "IDfunc",
                table: "Projetos");

            migrationBuilder.DropColumn(
                name: "Cargo",
                table: "Projetos");

            migrationBuilder.DropColumn(
                name: "CodPostal",
                table: "Projetos");

            migrationBuilder.DropColumn(
                name: "Contacto",
                table: "Projetos");

            migrationBuilder.DropColumn(
                name: "Morada",
                table: "Projetos");

            migrationBuilder.DropColumn(
                name: "UserNameId",
                table: "Projetos");

            migrationBuilder.DropColumn(
                name: "IDproj",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "Categoria",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "ClienteFK",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "Data",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "Ficheiro",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "Fotografia",
                table: "Funcionarios");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Projetos",
                maxLength: 70,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "IDproj",
                table: "Projetos",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Categoria",
                table: "Projetos",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ClienteFK",
                table: "Projetos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Data",
                table: "Projetos",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Projetos",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Ficheiro",
                table: "Projetos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Fotografia",
                table: "Projetos",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Funcionarios",
                maxLength: 70,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "IDfunc",
                table: "Funcionarios",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Cargo",
                table: "Funcionarios",
                maxLength: 70,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CodPostal",
                table: "Funcionarios",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Contacto",
                table: "Funcionarios",
                maxLength: 9,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Morada",
                table: "Funcionarios",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserNameId",
                table: "Funcionarios",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Clientes",
                maxLength: 70,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "NIF",
                table: "Clientes",
                maxLength: 9,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Contacto",
                table: "Clientes",
                maxLength: 9,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Projetos",
                table: "Projetos",
                column: "IDproj");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Funcionarios",
                table: "Funcionarios",
                column: "IDfunc");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c",
                column: "ConcurrencyStamp",
                value: "6e6c7b40-fc4b-48e9-99c8-2b06c28631ab");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f",
                column: "ConcurrencyStamp",
                value: "82bd8f7a-9105-4f57-a8e0-1fb300dc6e55");

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
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjetosFuncionarios_Funcionarios_IDfuncFK",
                table: "ProjetosFuncionarios",
                column: "IDfuncFK",
                principalTable: "Funcionarios",
                principalColumn: "IDfunc",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjetosFuncionarios_Projetos_IDprojFK",
                table: "ProjetosFuncionarios",
                column: "IDprojFK",
                principalTable: "Projetos",
                principalColumn: "IDproj",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projetos_Clientes_ClienteFK",
                table: "Projetos");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjetosFuncionarios_Funcionarios_IDfuncFK",
                table: "ProjetosFuncionarios");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjetosFuncionarios_Projetos_IDprojFK",
                table: "ProjetosFuncionarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Projetos",
                table: "Projetos");

            migrationBuilder.DropIndex(
                name: "IX_Projetos_ClienteFK",
                table: "Projetos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Funcionarios",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "IDproj",
                table: "Projetos");

            migrationBuilder.DropColumn(
                name: "Categoria",
                table: "Projetos");

            migrationBuilder.DropColumn(
                name: "ClienteFK",
                table: "Projetos");

            migrationBuilder.DropColumn(
                name: "Data",
                table: "Projetos");

            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Projetos");

            migrationBuilder.DropColumn(
                name: "Ficheiro",
                table: "Projetos");

            migrationBuilder.DropColumn(
                name: "Fotografia",
                table: "Projetos");

            migrationBuilder.DropColumn(
                name: "IDfunc",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "Cargo",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "CodPostal",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "Contacto",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "Morada",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "UserNameId",
                table: "Funcionarios");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Projetos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 70);

            migrationBuilder.AddColumn<int>(
                name: "IDfunc",
                table: "Projetos",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Cargo",
                table: "Projetos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CodPostal",
                table: "Projetos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Contacto",
                table: "Projetos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Morada",
                table: "Projetos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserNameId",
                table: "Projetos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Funcionarios",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 70);

            migrationBuilder.AddColumn<int>(
                name: "IDproj",
                table: "Funcionarios",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Categoria",
                table: "Funcionarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ClienteFK",
                table: "Funcionarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Data",
                table: "Funcionarios",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Funcionarios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ficheiro",
                table: "Funcionarios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Fotografia",
                table: "Funcionarios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 70);

            migrationBuilder.AlterColumn<string>(
                name: "NIF",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 9);

            migrationBuilder.AlterColumn<int>(
                name: "Contacto",
                table: "Clientes",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 9);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Projetos",
                table: "Projetos",
                column: "IDfunc");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Funcionarios",
                table: "Funcionarios",
                column: "IDproj");

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
                name: "IX_Funcionarios_ClienteFK",
                table: "Funcionarios",
                column: "ClienteFK");

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_Clientes_ClienteFK",
                table: "Funcionarios",
                column: "ClienteFK",
                principalTable: "Clientes",
                principalColumn: "IDcliente",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjetosFuncionarios_Projetos_IDfuncFK",
                table: "ProjetosFuncionarios",
                column: "IDfuncFK",
                principalTable: "Projetos",
                principalColumn: "IDfunc",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjetosFuncionarios_Funcionarios_IDprojFK",
                table: "ProjetosFuncionarios",
                column: "IDprojFK",
                principalTable: "Funcionarios",
                principalColumn: "IDproj",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
