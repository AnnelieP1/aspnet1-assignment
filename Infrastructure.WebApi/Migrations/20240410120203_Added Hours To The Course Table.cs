using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class AddedHoursToTheCourseTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Hours",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Hours",
                table: "Courses");
        }
    }
}
