using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaseDatosContext.Migrations
{
    /// <inheritdoc />
    public partial class DeporteEquipo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Deporte",
                table: "Torneos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deporte",
                table: "Torneos");
        }
    }
}
