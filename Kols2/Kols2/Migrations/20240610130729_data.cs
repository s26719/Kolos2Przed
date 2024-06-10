using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Kols2.Migrations
{
    /// <inheritdoc />
    public partial class data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Event",
                columns: new[] { "IdEvent", "DateFrom", "DateTo", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "CLOUT" },
                    { 2, new DateTime(2024, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Event2" }
                });

            migrationBuilder.InsertData(
                table: "Organiser",
                columns: new[] { "IdOrganiser", "Name" },
                values: new object[,]
                {
                    { 1, "admin1" },
                    { 2, "admin2" }
                });

            migrationBuilder.InsertData(
                table: "Event_Organiser",
                columns: new[] { "IdEvent", "IdOrganiser", "MainOrganiser" },
                values: new object[,]
                {
                    { 1, 1, true },
                    { 2, 2, false }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Event_Organiser",
                keyColumns: new[] { "IdEvent", "IdOrganiser" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Event_Organiser",
                keyColumns: new[] { "IdEvent", "IdOrganiser" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Event",
                keyColumn: "IdEvent",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Event",
                keyColumn: "IdEvent",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Organiser",
                keyColumn: "IdOrganiser",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Organiser",
                keyColumn: "IdOrganiser",
                keyValue: 2);
        }
    }
}
