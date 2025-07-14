using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightCrew.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Pilots",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "Pilots",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteDate",
                table: "Pilots",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Pilots",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Pilots",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedBy",
                table: "Pilots",
                type: "uniqueidentifier",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Pilots");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Pilots");

            migrationBuilder.DropColumn(
                name: "DeleteDate",
                table: "Pilots");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Pilots");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Pilots");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Pilots");
        }
    }
}
