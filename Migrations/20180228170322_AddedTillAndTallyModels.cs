using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace caja.Migrations
{
    public partial class AddedTillAndTallyModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tills",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Number = table.Column<int>(nullable: false),
                    Store = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tallies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Created = table.Column<DateTime>(nullable: false),
                    Final = table.Column<decimal>(nullable: false),
                    TillId = table.Column<int>(nullable: true),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tallies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tallies_Tills_TillId",
                        column: x => x.TillId,
                        principalTable: "Tills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tallies_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tallies_TillId",
                table: "Tallies",
                column: "TillId");

            migrationBuilder.CreateIndex(
                name: "IX_Tallies_UserId",
                table: "Tallies",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tallies");

            migrationBuilder.DropTable(
                name: "Tills");
        }
    }
}
