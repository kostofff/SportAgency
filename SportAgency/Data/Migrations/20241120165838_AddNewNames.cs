using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportAgency.Migrations
{
    /// <inheritdoc />
    public partial class AddNewNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Clubs",
                newName: "ClubId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Athletes",
                newName: "AthleteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ClubId",
                table: "Clubs",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "AthleteId",
                table: "Athletes",
                newName: "Id");
        }
    }
}
