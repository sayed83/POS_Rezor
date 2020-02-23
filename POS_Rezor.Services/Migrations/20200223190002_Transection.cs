using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace POS_Rezor.Services.Migrations
{
    public partial class Transection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Transections",
                columns: table => new
                {
                    TransectionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Month = table.Column<int>(nullable: false),
                    GivenDate = table.Column<DateTime>(nullable: false),
                    EntryDate = table.Column<DateTime>(nullable: true),
                    TransectionAmount = table.Column<float>(nullable: false),
                    userid = table.Column<int>(nullable: true),
                    comid = table.Column<int>(nullable: true),
                    MemberId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transections", x => x.TransectionId);
                    table.ForeignKey(
                        name: "FK_Transections_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transections_MemberId",
                table: "Transections",
                column: "MemberId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transections");
        }
    }
}
