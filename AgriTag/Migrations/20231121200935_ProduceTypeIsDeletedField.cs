using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgriTag.Migrations
{
    public partial class ProduceTypeIsDeletedField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ProduceTypes",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ProduceTypes");
        }
    }
}
