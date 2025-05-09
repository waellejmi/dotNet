using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WL_TP4.Migrations
{
    /// <inheritdoc />
    public partial class AddedTel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Tel",
                table: "HotelSet",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tel",
                table: "HotelSet");
        }
    }
}
