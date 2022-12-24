using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bookStoreV1.Migrations
{
    public partial class addMyBookId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MyBookId",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MyBookId",
                table: "Books");
        }
    }
}
