using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MemeIT.Migrations
{
    /// <inheritdoc />
    public partial class memesUserRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Meme",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Meme_UserId",
                table: "Meme",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Meme_User_UserId",
                table: "Meme",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meme_User_UserId",
                table: "Meme");

            migrationBuilder.DropIndex(
                name: "IX_Meme_UserId",
                table: "Meme");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Meme");
        }
    }
}
