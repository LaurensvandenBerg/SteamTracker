using Microsoft.EntityFrameworkCore.Migrations;

namespace SteamTracker.Data.Migrations
{
    public partial class removeforeignkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Players_GameForeignKey",
                table: "Games");

            migrationBuilder.RenameColumn(
                name: "GameForeignKey",
                table: "Games",
                newName: "PlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_Games_GameForeignKey",
                table: "Games",
                newName: "IX_Games_PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Players_PlayerId",
                table: "Games",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Players_PlayerId",
                table: "Games");

            migrationBuilder.RenameColumn(
                name: "PlayerId",
                table: "Games",
                newName: "GameForeignKey");

            migrationBuilder.RenameIndex(
                name: "IX_Games_PlayerId",
                table: "Games",
                newName: "IX_Games_GameForeignKey");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Players_GameForeignKey",
                table: "Games",
                column: "GameForeignKey",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
