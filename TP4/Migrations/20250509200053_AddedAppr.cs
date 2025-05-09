using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WL_TP4.Migrations
{
    /// <inheritdoc />
    public partial class AddedAppr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Appreciation",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PersName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false),
                    HotelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appreciation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appreciation_HotelSet_HotelId",
                        column: x => x.HotelId,
                        principalTable: "HotelSet",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appreciation_HotelId",
                table: "Appreciation",
                column: "HotelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appreciation");
        }
    }
}
