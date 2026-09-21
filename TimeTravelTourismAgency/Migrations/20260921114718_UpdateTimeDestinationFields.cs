using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeTravelTourismAgency.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTimeDestinationFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Capacity",
                table: "TimeDestinations",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "TimeDestinations",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DangerLevel",
                table: "TimeDestinations",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "TimeDestinations",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "TimeDestinations",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "TimeDestinations",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "TargetYear",
                table: "TimeDestinations",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "TimeDestinations",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Capacity",
                table: "TimeDestinations");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "TimeDestinations");

            migrationBuilder.DropColumn(
                name: "DangerLevel",
                table: "TimeDestinations");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "TimeDestinations");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "TimeDestinations");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "TimeDestinations");

            migrationBuilder.DropColumn(
                name: "TargetYear",
                table: "TimeDestinations");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "TimeDestinations");
        }
    }
}
