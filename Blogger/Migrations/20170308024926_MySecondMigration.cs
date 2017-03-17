using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Blogger.Migrations
{
    public partial class MySecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_PostTopics_Id",
                table: "PostTopics");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedOn",
                table: "Post",
                nullable: false,
                defaultValue: new DateTime(2017, 3, 7, 21, 49, 26, 430, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 3, 7, 21, 41, 15, 279, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "PublishedOn",
                table: "Post",
                nullable: false,
                defaultValue: new DateTime(2017, 3, 7, 21, 49, 26, 422, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 3, 7, 21, 41, 15, 271, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedOn",
                table: "Post",
                nullable: false,
                defaultValue: new DateTime(2017, 3, 7, 21, 41, 15, 279, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 3, 7, 21, 49, 26, 430, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "PublishedOn",
                table: "Post",
                nullable: false,
                defaultValue: new DateTime(2017, 3, 7, 21, 41, 15, 271, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 3, 7, 21, 49, 26, 422, DateTimeKind.Local));

            migrationBuilder.AddUniqueConstraint(
                name: "AK_PostTopics_Id",
                table: "PostTopics",
                column: "Id");
        }
    }
}
