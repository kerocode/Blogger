using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Blogger.Migrations
{
    public partial class MyThirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageContent",
                table: "HeaderImage");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedOn",
                table: "Post",
                nullable: false,
                defaultValue: new DateTime(2017, 3, 8, 0, 41, 32, 531, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 3, 7, 21, 49, 26, 430, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "PublishedOn",
                table: "Post",
                nullable: false,
                defaultValue: new DateTime(2017, 3, 8, 0, 41, 32, 520, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 3, 7, 21, 49, 26, 422, DateTimeKind.Local));

            migrationBuilder.AddColumn<string>(
                name: "imgUrl",
                table: "HeaderImage",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "imgUrl",
                table: "HeaderImage");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedOn",
                table: "Post",
                nullable: false,
                defaultValue: new DateTime(2017, 3, 7, 21, 49, 26, 430, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 3, 8, 0, 41, 32, 531, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "PublishedOn",
                table: "Post",
                nullable: false,
                defaultValue: new DateTime(2017, 3, 7, 21, 49, 26, 422, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 3, 8, 0, 41, 32, 520, DateTimeKind.Local));

            migrationBuilder.AddColumn<byte[]>(
                name: "ImageContent",
                table: "HeaderImage",
                nullable: true);
        }
    }
}
