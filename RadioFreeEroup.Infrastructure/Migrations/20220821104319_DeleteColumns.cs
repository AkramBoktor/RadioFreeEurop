using Microsoft.EntityFrameworkCore.Migrations;

namespace RadioFreeEroup.Infrastructure.Migrations
{
    public partial class DeleteColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "testdata",
                table: "JsonItems");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "testdata",
                table: "JsonItems",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
