using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaseDatosContext.Migrations
{
    /// <inheritdoc />
    public partial class cambiosPartido : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PartidoSiguienteId",
                table: "Partidos",
                newName: "Ronda");

            migrationBuilder.AddColumn<string>(
                name: "ImagenRef",
                table: "Torneos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "Partidos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "Orden",
                table: "Partidos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "PartidoSiguienteGuid",
                table: "Partidos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "RondaDescanso",
                table: "Partidos",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagenRef",
                table: "Torneos");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "Partidos");

            migrationBuilder.DropColumn(
                name: "Orden",
                table: "Partidos");

            migrationBuilder.DropColumn(
                name: "PartidoSiguienteGuid",
                table: "Partidos");

            migrationBuilder.DropColumn(
                name: "RondaDescanso",
                table: "Partidos");

            migrationBuilder.RenameColumn(
                name: "Ronda",
                table: "Partidos",
                newName: "PartidoSiguienteId");
        }
    }
}
