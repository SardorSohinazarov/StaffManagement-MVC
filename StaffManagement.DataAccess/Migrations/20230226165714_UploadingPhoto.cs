using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StaffManagement.DataAccess.Migrations
{
    public partial class UploadingPhoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoFilePath",
                table: "Staffs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoFilePath",
                table: "Staffs");
        }
    }
}
