using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TP6.Migrations
{
    /// <inheritdoc />
    public partial class NullWebSite : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "WebSite",
                table: "School",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.InsertData(
                table: "School",
                columns: new[] { "Id", "Director", "Name", "Rating", "Sections", "WebSite" },
                values: new object[,]
                {
                    { 1, "Dr. Helen Moore", "Green Valley High", 4.5, "Science, Arts, Sports", "https://greenvalley.edu" },
                    { 2, "Mr. John Ellis", "Lakeside Academy", 3.7999999999999998, "Mathematics, Humanities", null },
                    { 3, "Ms. Clara Dean", "Mountainview Institute", 4.9000000000000004, "Engineering, Computer Science", "https://mountainview.edu" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "School",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "School",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "School",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AlterColumn<string>(
                name: "WebSite",
                table: "School",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);
        }
    }
}
