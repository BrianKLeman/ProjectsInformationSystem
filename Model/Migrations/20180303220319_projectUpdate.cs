using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Projects.Migrations
{
    public partial class projectUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Stories_ProjectId",
                table: "Stories",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stories_Projects_ProjectId",
                table: "Stories",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stories_Projects_ProjectId",
                table: "Stories");

            migrationBuilder.DropIndex(
                name: "IX_Stories_ProjectId",
                table: "Stories");
        }
    }
}
