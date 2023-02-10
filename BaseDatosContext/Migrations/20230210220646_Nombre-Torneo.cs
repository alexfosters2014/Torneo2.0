using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaseDatosContext.Migrations
{
    /// <inheritdoc />
    public partial class NombreTorneo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Torneos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Torneos");
        }
    }
}
