using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotPizza.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class styleSeeded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Styles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Styles", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Styles",
                columns: new[] { "Id", "DisplayOrder", "Name" },
                values: new object[,]
                {
                    { 1, 1, "New York" },
                    { 2, 2, "Chicago" },
                    { 3, 3, "Detroit" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Styles");
        }
    }
}
