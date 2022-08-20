using Microsoft.EntityFrameworkCore.Migrations;

namespace RadioFreeEroup.Infrastructure.Migrations
{
    public partial class secondII : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemIDKey",
                table: "JsonItems");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ItemIDKey",
                table: "JsonItems",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
