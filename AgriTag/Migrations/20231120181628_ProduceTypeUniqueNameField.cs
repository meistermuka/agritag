using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgriTag.Migrations
{
    public partial class ProduceTypeUniqueNameField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ProduceTypes_Name",
                table: "ProduceTypes",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ProduceTypes_Name",
                table: "ProduceTypes");
        }
    }
}
