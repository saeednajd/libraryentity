using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mvc.Migrations
{
    /// <inheritdoc />
    public partial class mappingfinal6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Pages = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "bookShelves",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bookShelves", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shelves",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shelves", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Joindate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookShelfAndBooks",
                columns: table => new
                {
                    BookShelfId = table.Column<int>(type: "int", nullable: false),
                    BookID = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookShelfAndBooks", x => new { x.BookID, x.BookShelfId });
                    table.ForeignKey(
                        name: "FK_BookShelfAndBooks_Books_BookID",
                        column: x => x.BookID,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookShelfAndBooks_bookShelves_BookShelfId",
                        column: x => x.BookShelfId,
                        principalTable: "bookShelves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookShelfAndUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookShelfId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookShelfAndUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookShelfAndUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookShelfAndUsers_bookShelves_BookShelfId",
                        column: x => x.BookShelfId,
                        principalTable: "bookShelves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookShelfAndBooks_BookShelfId",
                table: "BookShelfAndBooks",
                column: "BookShelfId");

            migrationBuilder.CreateIndex(
                name: "IX_BookShelfAndUsers_BookShelfId",
                table: "BookShelfAndUsers",
                column: "BookShelfId");

            migrationBuilder.CreateIndex(
                name: "IX_BookShelfAndUsers_UserId",
                table: "BookShelfAndUsers",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookShelfAndBooks");

            migrationBuilder.DropTable(
                name: "BookShelfAndUsers");

            migrationBuilder.DropTable(
                name: "Shelves");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "bookShelves");
        }
    }
}
