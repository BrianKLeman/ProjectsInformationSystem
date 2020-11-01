using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Projects.Migrations
{
    public partial class taskUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Story_Iteration_IterationId",
                table: "Story");

            migrationBuilder.DropForeignKey(
                name: "FK_Task_Story_StoryId",
                table: "Task");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Task",
                table: "Task");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Story",
                table: "Story");

            migrationBuilder.RenameTable(
                name: "Task",
                newName: "Tasks");

            migrationBuilder.RenameTable(
                name: "Story",
                newName: "Stories");

            migrationBuilder.RenameIndex(
                name: "IX_Task_StoryId",
                table: "Tasks",
                newName: "IX_Tasks_StoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Story_IterationId",
                table: "Stories",
                newName: "IX_Stories_IterationId");

            migrationBuilder.AlterColumn<int>(
                name: "IterationId",
                table: "Stories",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "Stories",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks",
                column: "TaskId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stories",
                table: "Stories",
                column: "StoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stories_Iteration_IterationId",
                table: "Stories",
                column: "IterationId",
                principalTable: "Iteration",
                principalColumn: "IterationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Stories_StoryId",
                table: "Tasks",
                column: "StoryId",
                principalTable: "Stories",
                principalColumn: "StoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stories_Iteration_IterationId",
                table: "Stories");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Stories_StoryId",
                table: "Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Stories",
                table: "Stories");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Stories");

            migrationBuilder.RenameTable(
                name: "Tasks",
                newName: "Task");

            migrationBuilder.RenameTable(
                name: "Stories",
                newName: "Story");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_StoryId",
                table: "Task",
                newName: "IX_Task_StoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Stories_IterationId",
                table: "Story",
                newName: "IX_Story_IterationId");

            migrationBuilder.AlterColumn<int>(
                name: "IterationId",
                table: "Story",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Task",
                table: "Task",
                column: "TaskId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Story",
                table: "Story",
                column: "StoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Story_Iteration_IterationId",
                table: "Story",
                column: "IterationId",
                principalTable: "Iteration",
                principalColumn: "IterationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Task_Story_StoryId",
                table: "Task",
                column: "StoryId",
                principalTable: "Story",
                principalColumn: "StoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
