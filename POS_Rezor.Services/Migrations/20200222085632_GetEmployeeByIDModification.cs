using Microsoft.EntityFrameworkCore.Migrations;

namespace POS_Rezor.Services.Migrations
{
    public partial class GetEmployeeByIDModification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string prodedure = @"Alter procedure GetEmployeeByIds 
    @id int
    as
    begin
	select e.Name,e.Email,e.Department,e.PhotoPath,s.SectionName from Employees e
	inner join Sections s on e.SectionId =s.SectionId
	 where Id = @id
                                end";
            migrationBuilder.Sql(prodedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = "@Drop procedure GetEmployeeByIds";
            migrationBuilder.Sql(procedure);
        }
    }
}
