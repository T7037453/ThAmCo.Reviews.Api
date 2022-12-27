using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThAmCo.Reviews.Api.Migrations
{
    public partial class InitalMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    productId = table.Column<int>(type: "INTEGER", nullable: false),
                    productReviewContent = table.Column<string>(type: "TEXT", nullable: false),
                    productReviewRating = table.Column<int>(type: "INTEGER", nullable: false),
                    displayReview = table.Column<bool>(type: "INTEGER", nullable: false),
                    anonymized = table.Column<bool>(type: "INTEGER", nullable: false),
                    firstName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reviews");
        }
    }
}
