using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kols2.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    IdEvent = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    DateFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateTo = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.IdEvent);
                });

            migrationBuilder.CreateTable(
                name: "Organiser",
                columns: table => new
                {
                    IdOrganiser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organiser", x => x.IdOrganiser);
                });

            migrationBuilder.CreateTable(
                name: "Event_Organiser",
                columns: table => new
                {
                    IdEvent = table.Column<int>(type: "int", nullable: false),
                    IdOrganiser = table.Column<int>(type: "int", nullable: false),
                    MainOrganiser = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event_Organiser", x => new { x.IdEvent, x.IdOrganiser });
                    table.ForeignKey(
                        name: "FK_Event_Organiser_Event_IdEvent",
                        column: x => x.IdEvent,
                        principalTable: "Event",
                        principalColumn: "IdEvent",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Event_Organiser_Organiser_IdOrganiser",
                        column: x => x.IdOrganiser,
                        principalTable: "Organiser",
                        principalColumn: "IdOrganiser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Event_Organiser_IdOrganiser",
                table: "Event_Organiser",
                column: "IdOrganiser");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Event_Organiser");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "Organiser");
        }
    }
}
