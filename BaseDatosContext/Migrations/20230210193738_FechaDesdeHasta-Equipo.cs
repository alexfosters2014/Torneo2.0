using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaseDatosContext.Migrations
{
    /// <inheritdoc />
    public partial class FechaDesdeHastaEquipo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Desde",
                table: "Torneos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Hasta",
                table: "Torneos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Desde",
                table: "Torneos");

            migrationBuilder.DropColumn(
                name: "Hasta",
                table: "Torneos");
        }
    }
}
