using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class FixSubscriber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Subscribers",
                table: "Subscribers");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Subscribers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "Subscribers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "AdvertisingUpdates",
                table: "Subscribers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Subscribers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "DailyNewsletter",
                table: "Subscribers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "EventUpdates",
                table: "Subscribers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Podcasts",
                table: "Subscribers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "StartupsWeekly",
                table: "Subscribers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "WeekinReview",
                table: "Subscribers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Subscribers",
                table: "Subscribers",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Subscribers",
                table: "Subscribers");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Subscribers");

            migrationBuilder.DropColumn(
                name: "AdvertisingUpdates",
                table: "Subscribers");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Subscribers");

            migrationBuilder.DropColumn(
                name: "DailyNewsletter",
                table: "Subscribers");

            migrationBuilder.DropColumn(
                name: "EventUpdates",
                table: "Subscribers");

            migrationBuilder.DropColumn(
                name: "Podcasts",
                table: "Subscribers");

            migrationBuilder.DropColumn(
                name: "StartupsWeekly",
                table: "Subscribers");

            migrationBuilder.DropColumn(
                name: "WeekinReview",
                table: "Subscribers");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Subscribers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Subscribers",
                table: "Subscribers",
                column: "Email");
        }
    }
}
