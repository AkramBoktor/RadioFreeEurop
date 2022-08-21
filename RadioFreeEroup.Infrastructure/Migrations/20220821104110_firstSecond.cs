using Microsoft.EntityFrameworkCore.Migrations;

namespace RadioFreeEroup.Infrastructure.Migrations
{
    public partial class firstSecond : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "testdata",
                table: "JsonItems",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "testdata",
                table: "JsonItems");
        }
    }
}
