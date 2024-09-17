using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assesments.Data.Migrations
{
    /// <inheritdoc />
    public partial class seedingPriorities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                       table: "Priorities",
                       columns: new[] { "Id", "Name" },
                       values: new object[,]
                       {
                { 1, "Baja" },
                { 2, "Media" },
                { 3, "Alta" }
                       });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                       table: "Priorities",
                       keyColumn: "Id",
                       keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Priorities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Priorities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Priorities",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
