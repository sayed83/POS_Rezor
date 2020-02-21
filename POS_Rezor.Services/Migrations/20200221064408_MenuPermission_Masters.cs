using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace POS_Rezor.Services.Migrations
{
    public partial class MenuPermission_Masters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenuPermission_Details");

            migrationBuilder.DropTable(
                name: "MenuPermission_Masters");
        }
    }
}
