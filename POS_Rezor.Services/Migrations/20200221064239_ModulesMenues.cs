using Microsoft.EntityFrameworkCore.Migrations;

namespace POS_Rezor.Services.Migrations
{
    public partial class ModulesMenues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ModuleMenu_ImageCriteria_ImageCriteriaId",
                table: "ModuleMenu");

            migrationBuilder.DropForeignKey(
                name: "FK_ModuleMenu_ModuleGroups_ModuleGroupId",
                table: "ModuleMenu");

            migrationBuilder.DropForeignKey(
                name: "FK_ModuleMenu_Modules_ModulesModuleId",
                table: "ModuleMenu");

            migrationBuilder.DropForeignKey(
                name: "FK_ModuleMenu_ModuleMenu_ParentModuleMenuModuleMenuId",
                table: "ModuleMenu");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ModuleMenu",
                table: "ModuleMenu");

            migrationBuilder.RenameTable(
                name: "ModuleMenu",
                newName: "ModuleMenues");

            migrationBuilder.RenameIndex(
                name: "IX_ModuleMenu_ParentModuleMenuModuleMenuId",
                table: "ModuleMenues",
                newName: "IX_ModuleMenues_ParentModuleMenuModuleMenuId");

            migrationBuilder.RenameIndex(
                name: "IX_ModuleMenu_ModulesModuleId",
                table: "ModuleMenues",
                newName: "IX_ModuleMenues_ModulesModuleId");

            migrationBuilder.RenameIndex(
                name: "IX_ModuleMenu_ModuleGroupId",
                table: "ModuleMenues",
                newName: "IX_ModuleMenues_ModuleGroupId");

            migrationBuilder.RenameIndex(
                name: "IX_ModuleMenu_ImageCriteriaId",
                table: "ModuleMenues",
                newName: "IX_ModuleMenues_ImageCriteriaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ModuleMenues",
                table: "ModuleMenues",
                column: "ModuleMenuId");

            migrationBuilder.AddForeignKey(
                name: "FK_ModuleMenues_ImageCriteria_ImageCriteriaId",
                table: "ModuleMenues",
                column: "ImageCriteriaId",
                principalTable: "ImageCriteria",
                principalColumn: "ImageCriteriaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ModuleMenues_ModuleGroups_ModuleGroupId",
                table: "ModuleMenues",
                column: "ModuleGroupId",
                principalTable: "ModuleGroups",
                principalColumn: "ModuleGroupId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ModuleMenues_Modules_ModulesModuleId",
                table: "ModuleMenues",
                column: "ModulesModuleId",
                principalTable: "Modules",
                principalColumn: "ModuleId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ModuleMenues_ModuleMenues_ParentModuleMenuModuleMenuId",
                table: "ModuleMenues",
                column: "ParentModuleMenuModuleMenuId",
                principalTable: "ModuleMenues",
                principalColumn: "ModuleMenuId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ModuleMenues_ImageCriteria_ImageCriteriaId",
                table: "ModuleMenues");

            migrationBuilder.DropForeignKey(
                name: "FK_ModuleMenues_ModuleGroups_ModuleGroupId",
                table: "ModuleMenues");

            migrationBuilder.DropForeignKey(
                name: "FK_ModuleMenues_Modules_ModulesModuleId",
                table: "ModuleMenues");

            migrationBuilder.DropForeignKey(
                name: "FK_ModuleMenues_ModuleMenues_ParentModuleMenuModuleMenuId",
                table: "ModuleMenues");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ModuleMenues",
                table: "ModuleMenues");

            migrationBuilder.RenameTable(
                name: "ModuleMenues",
                newName: "ModuleMenu");

            migrationBuilder.RenameIndex(
                name: "IX_ModuleMenues_ParentModuleMenuModuleMenuId",
                table: "ModuleMenu",
                newName: "IX_ModuleMenu_ParentModuleMenuModuleMenuId");

            migrationBuilder.RenameIndex(
                name: "IX_ModuleMenues_ModulesModuleId",
                table: "ModuleMenu",
                newName: "IX_ModuleMenu_ModulesModuleId");

            migrationBuilder.RenameIndex(
                name: "IX_ModuleMenues_ModuleGroupId",
                table: "ModuleMenu",
                newName: "IX_ModuleMenu_ModuleGroupId");

            migrationBuilder.RenameIndex(
                name: "IX_ModuleMenues_ImageCriteriaId",
                table: "ModuleMenu",
                newName: "IX_ModuleMenu_ImageCriteriaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ModuleMenu",
                table: "ModuleMenu",
                column: "ModuleMenuId");

            migrationBuilder.AddForeignKey(
                name: "FK_ModuleMenu_ImageCriteria_ImageCriteriaId",
                table: "ModuleMenu",
                column: "ImageCriteriaId",
                principalTable: "ImageCriteria",
                principalColumn: "ImageCriteriaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ModuleMenu_ModuleGroups_ModuleGroupId",
                table: "ModuleMenu",
                column: "ModuleGroupId",
                principalTable: "ModuleGroups",
                principalColumn: "ModuleGroupId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ModuleMenu_Modules_ModulesModuleId",
                table: "ModuleMenu",
                column: "ModulesModuleId",
                principalTable: "Modules",
                principalColumn: "ModuleId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ModuleMenu_ModuleMenu_ParentModuleMenuModuleMenuId",
                table: "ModuleMenu",
                column: "ParentModuleMenuModuleMenuId",
                principalTable: "ModuleMenu",
                principalColumn: "ModuleMenuId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
