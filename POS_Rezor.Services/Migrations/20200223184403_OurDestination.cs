using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace POS_Rezor.Services.Migrations
{
    public partial class OurDestination : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BloodGroup",
                columns: table => new
                {
                    BloodGroupId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BloodGroupName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodGroup", x => x.BloodGroupId);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    MemberId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberName = table.Column<string>(nullable: false),
                    JoiningDate = table.Column<string>(nullable: true),
                    FatherName = table.Column<string>(nullable: true),
                    MotherName = table.Column<string>(nullable: true),
                    SpouseName = table.Column<string>(nullable: true),
                    Nationality = table.Column<string>(nullable: true),
                    DOB = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    PhotoPath = table.Column<string>(nullable: true),
                    Image = table.Column<byte[]>(nullable: true),
                    PhoneNo = table.Column<string>(nullable: false),
                    MaritalStatus = table.Column<int>(nullable: true),
                    Religion = table.Column<int>(nullable: true),
                    Gender = table.Column<int>(nullable: true),
                    EducationalQualification = table.Column<string>(nullable: true),
                    NIDNo = table.Column<string>(nullable: true),
                    PassportNo = table.Column<string>(nullable: true),
                    TinNo = table.Column<string>(nullable: true),
                    PresentAddress = table.Column<string>(nullable: true),
                    PermanentAddress = table.Column<string>(nullable: true),
                    NomineeName = table.Column<string>(nullable: true),
                    RelationWithNominee = table.Column<string>(nullable: true),
                    NomineeNIDNo = table.Column<string>(nullable: true),
                    NomineePhoneNo = table.Column<string>(nullable: true),
                    userid = table.Column<int>(nullable: false),
                    comid = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    EntryDate = table.Column<string>(nullable: true),
                    BloodGroupId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.MemberId);
                    table.ForeignKey(
                        name: "FK_Members_BloodGroup_BloodGroupId",
                        column: x => x.BloodGroupId,
                        principalTable: "BloodGroup",
                        principalColumn: "BloodGroupId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Committees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Position = table.Column<string>(nullable: false),
                    ElactedDate = table.Column<DateTime>(nullable: true),
                    userid = table.Column<int>(nullable: true),
                    comid = table.Column<int>(nullable: true),
                    EntryDate = table.Column<DateTime>(nullable: true),
                    AddedBy = table.Column<string>(nullable: true),
                    MemberId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Committees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Committees_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Expensess",
                columns: table => new
                {
                    ExpenceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpensesName = table.Column<string>(nullable: false),
                    ExpensesAmnount = table.Column<float>(nullable: false),
                    ExpensesDate = table.Column<DateTime>(nullable: true),
                    ExpensesDec = table.Column<string>(nullable: true),
                    userid = table.Column<int>(nullable: true),
                    comid = table.Column<int>(nullable: true),
                    EntryDate = table.Column<DateTime>(nullable: true),
                    AddedBy = table.Column<string>(nullable: true),
                    MemberId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expensess", x => x.ExpenceId);
                    table.ForeignKey(
                        name: "FK_Expensess_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Invests",
                columns: table => new
                {
                    InvestId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvestPurpose = table.Column<string>(nullable: false),
                    InvestAmount = table.Column<float>(nullable: false),
                    InvestDate = table.Column<DateTime>(nullable: false),
                    ExpireDate = table.Column<DateTime>(nullable: false),
                    userid = table.Column<int>(nullable: true),
                    comid = table.Column<int>(nullable: true),
                    EntryDate = table.Column<DateTime>(nullable: true),
                    AddedBy = table.Column<string>(nullable: true),
                    MemberId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invests", x => x.InvestId);
                    table.ForeignKey(
                        name: "FK_Invests_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Profits",
                columns: table => new
                {
                    ProfitId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfitDec = table.Column<string>(nullable: false),
                    ProfitAmount = table.Column<float>(nullable: false),
                    GivenDate = table.Column<DateTime>(nullable: false),
                    userid = table.Column<int>(nullable: true),
                    comid = table.Column<int>(nullable: true),
                    EntryDate = table.Column<DateTime>(nullable: true),
                    AddedBy = table.Column<string>(nullable: true),
                    InvestId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profits", x => x.ProfitId);
                    table.ForeignKey(
                        name: "FK_Profits_Invests_InvestId",
                        column: x => x.InvestId,
                        principalTable: "Invests",
                        principalColumn: "InvestId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Committees_MemberId",
                table: "Committees",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Expensess_MemberId",
                table: "Expensess",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Invests_MemberId",
                table: "Invests",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_BloodGroupId",
                table: "Members",
                column: "BloodGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Profits_InvestId",
                table: "Profits",
                column: "InvestId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Committees");

            migrationBuilder.DropTable(
                name: "Expensess");

            migrationBuilder.DropTable(
                name: "Profits");

            migrationBuilder.DropTable(
                name: "Invests");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "BloodGroup");
        }
    }
}
