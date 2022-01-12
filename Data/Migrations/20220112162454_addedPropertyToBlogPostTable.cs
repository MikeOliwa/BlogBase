using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogBase.Data.Migrations
{
    public partial class addedPropertyToBlogPostTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateEdited",
                table: "BlogPosts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "PreviewText",
                table: "BlogPosts",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateEdited",
                table: "BlogPosts");

            migrationBuilder.DropColumn(
                name: "PreviewText",
                table: "BlogPosts");
        }
    }
}
