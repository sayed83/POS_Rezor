using Microsoft.EntityFrameworkCore.Migrations;

namespace POS_Rezor.Services.Migrations
{
    public partial class GetEmployeeById : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string prodedure = @"Create procedure GetEmployeeByIds 
                                @id int
                                as
                                begin
	                                select * from Employees where Id = @id
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
