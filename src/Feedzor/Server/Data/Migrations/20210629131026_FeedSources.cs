using Microsoft.EntityFrameworkCore.Migrations;

namespace Feedzor.Server.Data.Migrations
{
    public partial class FeedSources : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FeedItems_FeedSouces_FeedSourceId",
                table: "FeedItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FeedSouces",
                table: "FeedSouces");

            migrationBuilder.RenameTable(
                name: "FeedSouces",
                newName: "FeedSources");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FeedSources",
                table: "FeedSources",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FeedItems_FeedSources_FeedSourceId",
                table: "FeedItems",
                column: "FeedSourceId",
                principalTable: "FeedSources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FeedItems_FeedSources_FeedSourceId",
                table: "FeedItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FeedSources",
                table: "FeedSources");

            migrationBuilder.RenameTable(
                name: "FeedSources",
                newName: "FeedSouces");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FeedSouces",
                table: "FeedSouces",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FeedItems_FeedSouces_FeedSourceId",
                table: "FeedItems",
                column: "FeedSourceId",
                principalTable: "FeedSouces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
