using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportAgency.Migrations
{
    /// <inheritdoc />
    public partial class AddNewFieldss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Clubs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Age",
                table: "Athletes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "Clubs");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "Athletes");
        }
    }
}
