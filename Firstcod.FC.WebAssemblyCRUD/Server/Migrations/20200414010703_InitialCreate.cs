using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Firstcod.FC.WebAssemblyCRUD.Server.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppMembers",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: true),
                    Password = table.Column<byte[]>(nullable: true),
                    Roles = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    StateId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppMembers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppMembers_EmailAddress",
                table: "AppMembers",
                column: "EmailAddress",
                unique: true,
                filter: "[EmailAddress] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppMembers");
        }
    }
}
