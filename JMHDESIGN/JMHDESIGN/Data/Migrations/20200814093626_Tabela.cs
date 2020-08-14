using Microsoft.EntityFrameworkCore.Migrations;

namespace JMHDESIGN.Data.Migrations
{
    public partial class Tabela : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c", "51fffe77-cb44-4625-b6cc-06c66a413bf1", "cliente", "cliente" },
                    { "f", "42ca3339-57fa-4f5a-811f-c78d4003ae30", "funcionario", "funcionario" }
                });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
