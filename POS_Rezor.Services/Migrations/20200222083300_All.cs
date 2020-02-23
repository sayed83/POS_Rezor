using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace POS_Rezor.Services.Migrations
{
    public partial class All : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    PhotoPath = table.Column<string>(nullable: true),
                    Department = table.Column<int>(nullable: true),
                    SectionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ImageCriterias",
                columns: table => new
                {
                    ImageCriteriaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageCriteriaCaption = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageCriterias", x => x.ImageCriteriaId);
                });

            migrationBuilder.CreateTable(
                name: "MenuPermission_Masters",
                columns: table => new
                {
                    MenuPermissionMasterId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    useridPermission = table.Column<string>(nullable: true),
                    comid = table.Column<int>(nullable: false),
                    userid = table.Column<string>(nullable: true),
                    useridUpdate = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    AddedBy = table.Column<string>(nullable: true),
                    AddedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuPermission_Masters", x => x.MenuPermissionMasterId);
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
                name: "Sections",
                columns: table => new
                {
                    SectionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SectionName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.SectionId);
                });

            migrationBuilder.CreateTable(
                name: "ModuleGroups",
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
                    table.PrimaryKey("PK_ModuleGroups", x => x.ModuleGroupId);
                    table.ForeignKey(
                        name: "FK_ModuleGroups_Modules_ModulesModuleId",
                        column: x => x.ModulesModuleId,
                        principalTable: "Modules",
                        principalColumn: "ModuleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ModuleMenues",
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
                    table.PrimaryKey("PK_ModuleMenues", x => x.ModuleMenuId);
                    table.ForeignKey(
                        name: "FK_ModuleMenues_ImageCriterias_ImageCriteriaId",
                        column: x => x.ImageCriteriaId,
                        principalTable: "ImageCriterias",
                        principalColumn: "ImageCriteriaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModuleMenues_ModuleGroups_ModuleGroupId",
                        column: x => x.ModuleGroupId,
                        principalTable: "ModuleGroups",
                        principalColumn: "ModuleGroupId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModuleMenues_Modules_ModulesModuleId",
                        column: x => x.ModulesModuleId,
                        principalTable: "Modules",
                        principalColumn: "ModuleId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ModuleMenues_ModuleMenues_ParentModuleMenuModuleMenuId",
                        column: x => x.ParentModuleMenuModuleMenuId,
                        principalTable: "ModuleMenues",
                        principalColumn: "ModuleMenuId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MenuPermission_Details",
                columns: table => new
                {
                    MenuPermissionDetailsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsCreated = table.Column<bool>(nullable: false),
                    IsUpdated = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsView = table.Column<bool>(nullable: false),
                    IsReport = table.Column<bool>(nullable: false),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true),
                    MenuPermissionMasterId = table.Column<int>(nullable: false),
                    MenuPermission_MasterMenuPermissionMasterId = table.Column<int>(nullable: true),
                    ModuleMenuId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuPermission_Details", x => x.MenuPermissionDetailsId);
                    table.ForeignKey(
                        name: "FK_MenuPermission_Details_MenuPermission_Masters_MenuPermission_MasterMenuPermissionMasterId",
                        column: x => x.MenuPermission_MasterMenuPermissionMasterId,
                        principalTable: "MenuPermission_Masters",
                        principalColumn: "MenuPermissionMasterId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MenuPermission_Details_ModuleMenues_ModuleMenuId",
                        column: x => x.ModuleMenuId,
                        principalTable: "ModuleMenues",
                        principalColumn: "ModuleMenuId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MenuPermission_Details_MenuPermission_MasterMenuPermissionMasterId",
                table: "MenuPermission_Details",
                column: "MenuPermission_MasterMenuPermissionMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuPermission_Details_ModuleMenuId",
                table: "MenuPermission_Details",
                column: "ModuleMenuId");

            migrationBuilder.CreateIndex(
                name: "IX_ModuleGroups_ModulesModuleId",
                table: "ModuleGroups",
                column: "ModulesModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_ModuleMenues_ImageCriteriaId",
                table: "ModuleMenues",
                column: "ImageCriteriaId");

            migrationBuilder.CreateIndex(
                name: "IX_ModuleMenues_ModuleGroupId",
                table: "ModuleMenues",
                column: "ModuleGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_ModuleMenues_ModulesModuleId",
                table: "ModuleMenues",
                column: "ModulesModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_ModuleMenues_ParentModuleMenuModuleMenuId",
                table: "ModuleMenues",
                column: "ParentModuleMenuModuleMenuId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "MenuPermission_Details");

            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.DropTable(
                name: "MenuPermission_Masters");

            migrationBuilder.DropTable(
                name: "ModuleMenues");

            migrationBuilder.DropTable(
                name: "ImageCriterias");

            migrationBuilder.DropTable(
                name: "ModuleGroups");

            migrationBuilder.DropTable(
                name: "Modules");
        }
    }
}
