using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace POS_Rezor.Services.Migrations
{
    public partial class Modules : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ImageCriteria",
                columns: table => new
                {
                    ImageCriteriaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageCriteriaCaption = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageCriteria", x => x.ImageCriteriaId);
                });

            migrationBuilder.CreateTable(
                name: "Modules",
                columns: table => new
                {
                    ModuleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModuleCode = table.Column<string>(nullable: true),
                    ModuleName = table.Column<string>(nullable: true),
                    ModuleCaption = table.Column<string>(nullable: true),
                    ModuleDescription = table.Column<string>(nullable: true),
                    ModuleLink = table.Column<string>(nullable: true),
                    ModuleImage = table.Column<byte[]>(nullable: true),
                    ModuleImagePath = table.Column<string>(nullable: true),
                    ModuleImageExtension = table.Column<string>(nullable: true),
                    IsInActive = table.Column<int>(nullable: false),
                    SLNO = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modules", x => x.ModuleId);
                });

            migrationBuilder.CreateTable(
                name: "ModuleGroup",
                columns: table => new
                {
                    ModuleGroupId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModuleGroupName = table.Column<string>(nullable: true),
                    ModuleGroupCaption = table.Column<string>(nullable: true),
                    ModuleGroupImage = table.Column<byte[]>(nullable: true),
                    ImagePath = table.Column<string>(nullable: true),
                    ImageExtension = table.Column<string>(nullable: true),
                    SLNO = table.Column<int>(nullable: true),
                    ModuleId = table.Column<int>(nullable: false),
                    ModulesModuleId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModuleGroup", x => x.ModuleGroupId);
                    table.ForeignKey(
                        name: "FK_ModuleGroup_Modules_ModulesModuleId",
                        column: x => x.ModulesModuleId,
                        principalTable: "Modules",
                        principalColumn: "ModuleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ModuleMenu",
                columns: table => new
                {
                    ModuleMenuId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModuleMenuName = table.Column<string>(nullable: true),
                    ModuleMenuCaption = table.Column<string>(nullable: true),
                    ModuleMenuImage = table.Column<byte[]>(nullable: true),
                    ImagePath = table.Column<string>(nullable: true),
                    ModuleImageExtension = table.Column<string>(nullable: true),
                    ModuleMenuController = table.Column<string>(nullable: true),
                    ModuleMenuLink = table.Column<string>(nullable: true),
                    IsInActive = table.Column<int>(nullable: false),
                    IsParent = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    SLNO = table.Column<int>(nullable: true),
                    ModuleId = table.Column<int>(nullable: false),
                    ModulesModuleId = table.Column<int>(nullable: true),
                    ModuleGroupId = table.Column<int>(nullable: false),
                    ImageCriteriaId = table.Column<int>(nullable: false),
                    ParentId = table.Column<int>(nullable: false),
                    ParentModuleMenuModuleMenuId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModuleMenu", x => x.ModuleMenuId);
                    table.ForeignKey(
                        name: "FK_ModuleMenu_ImageCriteria_ImageCriteriaId",
                        column: x => x.ImageCriteriaId,
                        principalTable: "ImageCriteria",
                        principalColumn: "ImageCriteriaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModuleMenu_ModuleGroup_ModuleGroupId",
                        column: x => x.ModuleGroupId,
                        principalTable: "ModuleGroup",
                        principalColumn: "ModuleGroupId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModuleMenu_Modules_ModulesModuleId",
                        column: x => x.ModulesModuleId,
                        principalTable: "Modules",
                        principalColumn: "ModuleId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ModuleMenu_ModuleMenu_ParentModuleMenuModuleMenuId",
                        column: x => x.ParentModuleMenuModuleMenuId,
                        principalTable: "ModuleMenu",
                        principalColumn: "ModuleMenuId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ModuleGroup_ModulesModuleId",
                table: "ModuleGroup",
                column: "ModulesModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_ModuleMenu_ImageCriteriaId",
                table: "ModuleMenu",
                column: "ImageCriteriaId");

            migrationBuilder.CreateIndex(
                name: "IX_ModuleMenu_ModuleGroupId",
                table: "ModuleMenu",
                column: "ModuleGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_ModuleMenu_ModulesModuleId",
                table: "ModuleMenu",
                column: "ModulesModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_ModuleMenu_ParentModuleMenuModuleMenuId",
                table: "ModuleMenu",
                column: "ParentModuleMenuModuleMenuId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ModuleMenu");

            migrationBuilder.DropTable(
                name: "ImageCriteria");

            migrationBuilder.DropTable(
                name: "ModuleGroup");

            migrationBuilder.DropTable(
                name: "Modules");
        }
    }
}
