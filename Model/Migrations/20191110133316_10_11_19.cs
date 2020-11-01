using Microsoft.EntityFrameworkCore.Migrations;

namespace Projects.Migrations
{
    public partial class _10_11_19 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Release_Projects_ProjectId",
                table: "Release");

            migrationBuilder.RenameColumn(
                name: "TaskId",
                table: "Tasks",
                newName: "StoryTaskId");

            migrationBuilder.AddColumn<int>(
                name: "ReleaseId",
                table: "Stories",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "Release",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Release_Projects_ProjectId",
                table: "Release",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Release_Projects_ProjectId",
                table: "Release");

            migrationBuilder.DropColumn(
                name: "ReleaseId",
                table: "Stories");

            migrationBuilder.RenameColumn(
                name: "StoryTaskId",
                table: "Tasks",
                newName: "TaskId");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "Release",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Release_Projects_ProjectId",
                table: "Release",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
