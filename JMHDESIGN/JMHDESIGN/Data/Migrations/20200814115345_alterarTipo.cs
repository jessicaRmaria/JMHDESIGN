using Microsoft.EntityFrameworkCore.Migrations;

namespace JMHDESIGN.Data.Migrations
{
    public partial class alterarTipo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Morada",
                table: "Projetos",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "UserNameId",
                table: "Projetos",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Clientes",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f");

            migrationBuilder.DropColumn(
                name: "UserNameId",
                table: "Projetos");

            migrationBuilder.AlterColumn<int>(
                name: "Morada",
                table: "Projetos",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
