using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EunmiKim_Assignment1.Migrations
{
    /// <inheritdoc />
    public partial class AddSeeData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "BpMeasurements");

            migrationBuilder.InsertData(
                table: "BpMeasurements",
                columns: new[] { "Id", "DiastolicValue", "Position", "ReadingDate", "SystolicValue" },
                values: new object[,]
                {
                    { 1, 78, "Sitting", new DateTime(1996, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 118 },
                    { 2, 79, "Sitting", new DateTime(1998, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 120 },
                    { 3, 85, "Standing", new DateTime(2002, 11, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 131 },
                    { 4, 91, "Lying down", new DateTime(2005, 12, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 142 },
                    { 5, 121, "Standing", new DateTime(2008, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 181 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BpMeasurements",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BpMeasurements",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BpMeasurements",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BpMeasurements",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "BpMeasurements",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "BpMeasurements",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
