using Microsoft.EntityFrameworkCore.Migrations;

namespace POS_Rezor.Services.Migrations
{
    public partial class spInsertEmployeeModify : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"ALTER Proc [dbo].[spInsertEmployee]
@Name nvarchar(100),
@Email nvarchar(100),
@PhotoPath nvarchar(100),
@Dept int,
@Section int
AS
BEGIN
    INSERT INTO Employees
    (Name, Email, PhotoPath, Department,SectionId)

    VALUES(@Name, @Email, @PhotoPath, @Dept,@Section)
END";
            migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Drop Proc spInsertEmployee";
            migrationBuilder.Sql(procedure);
        }
    }
}
