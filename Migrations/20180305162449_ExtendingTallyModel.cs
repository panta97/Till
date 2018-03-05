using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace caja.Migrations
{
    public partial class ExtendingTallyModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tallies_Tills_TillId",
                table: "Tallies");

            migrationBuilder.DropForeignKey(
                name: "FK_Tallies_Users_UserId",
                table: "Tallies");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Tallies",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TillId",
                table: "Tallies",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tallies_Tills_TillId",
                table: "Tallies",
                column: "TillId",
                principalTable: "Tills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tallies_Users_UserId",
                table: "Tallies",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tallies_Tills_TillId",
                table: "Tallies");

            migrationBuilder.DropForeignKey(
                name: "FK_Tallies_Users_UserId",
                table: "Tallies");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Tallies",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "TillId",
                table: "Tallies",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Tallies_Tills_TillId",
                table: "Tallies",
                column: "TillId",
                principalTable: "Tills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tallies_Users_UserId",
                table: "Tallies",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
