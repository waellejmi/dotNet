using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WL_TP4.Migrations
{
    /// <inheritdoc />
    public partial class AddedCountry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "HotelSet",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "Tunisia");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "HotelSet");
        }
    }
}
