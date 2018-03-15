using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace caja.Migrations
{
    public partial class AddedStoreModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Store",
                table: "Tills");

            migrationBuilder.AddColumn<int>(
                name: "StoreId",
                table: "Tills",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tills_StoreId",
                table: "Tills",
                column: "StoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tills_Stores_StoreId",
                table: "Tills",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tills_Stores_StoreId",
                table: "Tills");

            migrationBuilder.DropTable(
                name: "Stores");

            migrationBuilder.DropIndex(
                name: "IX_Tills_StoreId",
                table: "Tills");

            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "Tills");

            migrationBuilder.AddColumn<string>(
                name: "Store",
                table: "Tills",
                nullable: true);
        }
    }
}
