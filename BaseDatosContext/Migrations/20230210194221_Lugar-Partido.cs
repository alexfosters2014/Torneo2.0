using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaseDatosContext.Migrations
{
    /// <inheritdoc />
    public partial class LugarPartido : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Lugar",
                table: "Torneos");

            migrationBuilder.AddColumn<string>(
                name: "Lugar",
                table: "Partidos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Lugar",
                table: "Partidos");

            migrationBuilder.AddColumn<string>(
                name: "Lugar",
                table: "Torneos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
