using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightCrew.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pilots",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Info_Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Info_Age = table.Column<int>(type: "int", nullable: false),
                    Info_Gender = table.Column<int>(type: "int", nullable: false),
                    Info_Nationality = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    VehicleRestriction = table.Column<int>(type: "int", nullable: false),
                    AllowedRange_Distance = table.Column<double>(type: "float", nullable: false),
                    SeniorityLevel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pilots", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PilotLanguages",
                columns: table => new
                {
                    PilotInfoPilotId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PilotLanguages", x => new { x.PilotInfoPilotId, x.Id });
                    table.ForeignKey(
                        name: "FK_PilotLanguages_Pilots_PilotInfoPilotId",
                        column: x => x.PilotInfoPilotId,
                        principalTable: "Pilots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PilotLanguages");

            migrationBuilder.DropTable(
                name: "Pilots");
        }
    }
}
