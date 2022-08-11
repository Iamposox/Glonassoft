using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GlonasSoft.BL.Migrations
{
    public partial class AddBaseEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "UserStatistics",
                newName: "StartDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "UserStatistics",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "UserStatistics",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "UserStatistics");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "UserStatistics");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "UserStatistics",
                newName: "Date");
        }
    }
}
