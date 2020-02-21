using Microsoft.EntityFrameworkCore.Migrations;

namespace POS_Rezor.Services.Migrations
{
    public partial class ModulesGroups : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ModuleGroup_Modules_ModulesModuleId",
                table: "ModuleGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_ModuleMenu_ModuleGroup_ModuleGroupId",
                table: "ModuleMenu");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ModuleGroup",
                table: "ModuleGroup");

            migrationBuilder.RenameTable(
                name: "ModuleGroup",
                newName: "ModuleGroups");

            migrationBuilder.RenameIndex(
                name: "IX_ModuleGroup_ModulesModuleId",
                table: "ModuleGroups",
                newName: "IX_ModuleGroups_ModulesModuleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ModuleGroups",
                table: "ModuleGroups",
                column: "ModuleGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_ModuleGroups_Modules_ModulesModuleId",
                table: "ModuleGroups",
                column: "ModulesModuleId",
                principalTable: "Modules",
                principalColumn: "ModuleId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ModuleMenu_ModuleGroups_ModuleGroupId",
                table: "ModuleMenu",
                column: "ModuleGroupId",
                principalTable: "ModuleGroups",
                principalColumn: "ModuleGroupId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ModuleGroups_Modules_ModulesModuleId",
                table: "ModuleGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_ModuleMenu_ModuleGroups_ModuleGroupId",
                table: "ModuleMenu");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ModuleGroups",
                table: "ModuleGroups");

            migrationBuilder.RenameTable(
                name: "ModuleGroups",
                newName: "ModuleGroup");

            migrationBuilder.RenameIndex(
                name: "IX_ModuleGroups_ModulesModuleId",
                table: "ModuleGroup",
                newName: "IX_ModuleGroup_ModulesModuleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ModuleGroup",
                table: "ModuleGroup",
                column: "ModuleGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_ModuleGroup_Modules_ModulesModuleId",
                table: "ModuleGroup",
                column: "ModulesModuleId",
                principalTable: "Modules",
                principalColumn: "ModuleId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ModuleMenu_ModuleGroup_ModuleGroupId",
                table: "ModuleMenu",
                column: "ModuleGroupId",
                principalTable: "ModuleGroup",
                principalColumn: "ModuleGroupId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
