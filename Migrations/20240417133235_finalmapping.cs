using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mvc.Migrations
{
    /// <inheritdoc />
    public partial class finalmapping : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookShelfAndShelves",
                columns: table => new
                {
                    BookshelfId = table.Column<int>(type: "int", nullable: false),
                    ShelfId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookShelfAndShelves", x => new { x.BookshelfId, x.ShelfId });
                    table.ForeignKey(
                        name: "FK_BookShelfAndShelves_Shelves_ShelfId",
                        column: x => x.ShelfId,
                        principalTable: "Shelves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookShelfAndShelves_bookShelves_BookshelfId",
                        column: x => x.BookshelfId,
                        principalTable: "bookShelves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookShelfAndShelves_ShelfId",
                table: "BookShelfAndShelves",
                column: "ShelfId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookShelfAndShelves");
        }
    }
}
