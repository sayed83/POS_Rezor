using POS_Rezor.Models;
using System;
using System.Collections.Generic;

namespace POS_Rezor.Services
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> Search(string searchTerm);
        IEnumerable<Employee> GetAllEmployees();
        Employee GetEmployee(int id);
        Employee Update(Employee employee);
        Employee Add(Employee newEmployee);
        Employee Delete(int id);
        //IEnumerable<DeptHeadCount> EmployeeCountByDept();
        IEnumerable<DeptHeadCount> EmployeeCountByDept(Dept? dept);
    }
}
