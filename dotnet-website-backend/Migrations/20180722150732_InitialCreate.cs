using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dotnetwebsitebackend.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    title = table.Column<string>(nullable: true),
                    content = table.Column<string>(nullable: true),
                    category = table.Column<string>(nullable: true),
                    allowComments = table.Column<bool>(nullable: false),
                    createdAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");
        }
    }
}
