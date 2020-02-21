using Microsoft.EntityFrameworkCore.Migrations;

namespace POS_Rezor.Services.Migrations
{
    public partial class ImageCriterias : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ModuleMenues_ImageCriteria_ImageCriteriaId",
                table: "ModuleMenues");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImageCriteria",
                table: "ImageCriteria");

            migrationBuilder.RenameTable(
                name: "ImageCriteria",
                newName: "ImageCriterias");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImageCriterias",
                table: "ImageCriterias",
                column: "ImageCriteriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_ModuleMenues_ImageCriterias_ImageCriteriaId",
                table: "ModuleMenues",
                column: "ImageCriteriaId",
                principalTable: "ImageCriterias",
                principalColumn: "ImageCriteriaId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ModuleMenues_ImageCriterias_ImageCriteriaId",
                table: "ModuleMenues");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImageCriterias",
                table: "ImageCriterias");

            migrationBuilder.RenameTable(
                name: "ImageCriterias",
                newName: "ImageCriteria");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImageCriteria",
                table: "ImageCriteria",
                column: "ImageCriteriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_ModuleMenues_ImageCriteria_ImageCriteriaId",
                table: "ModuleMenues",
                column: "ImageCriteriaId",
                principalTable: "ImageCriteria",
                principalColumn: "ImageCriteriaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
