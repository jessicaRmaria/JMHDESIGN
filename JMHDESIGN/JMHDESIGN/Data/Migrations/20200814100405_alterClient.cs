using Microsoft.EntityFrameworkCore.Migrations;

namespace JMHDESIGN.Data.Migrations
{
    public partial class alterClient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NIF",
                table: "Clientes",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NIF",
                table: "Clientes");
        }
    }
}
