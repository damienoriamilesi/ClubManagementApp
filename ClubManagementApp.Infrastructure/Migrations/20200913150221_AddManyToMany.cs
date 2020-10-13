using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClubManagementApp.Infrastructure.Migrations
{
    public partial class AddManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Cotisations",
                table: "Cotisations");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Cotisations",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cotisations",
                table: "Cotisations",
                columns: new[] { "UserId", "LicenceId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Cotisations_Users_UserId",
                table: "Cotisations",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cotisations_Users_UserId",
                table: "Cotisations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cotisations",
                table: "Cotisations");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Cotisations");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cotisations",
                table: "Cotisations",
                column: "Id");
        }
    }
}
