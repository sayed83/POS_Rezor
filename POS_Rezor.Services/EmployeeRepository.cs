using POS_Rezor.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace POS_Rezor.Services
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext context;

        public EmployeeRepository(AppDbContext context)
        {
            this.context = context;
        }
        public Employee Add(Employee newEmployee)
        {
            //data insert by using store Procedure
            context.Database.ExecuteSqlRaw("spInsertEmployee {0},{1},{2},{3}", newEmployee.Name, newEmployee.Email, newEmployee.PhotoPath, newEmployee.Department);
         
            //context.Employees.Add(newEmployee);
            //context.SaveChanges();
            return newEmployee;
        }

        public Employee Delete(int id)
        {
            Employee employee = context.Employees.Find(id);
            context.Employees.Remove(employee);
            context.SaveChanges();
            return employee;
        }

        public IEnumerable<DeptHeadCount> EmployeeCountByDept(Dept? dept)
        {
            IEnumerable<Employee> employees = context.Employees;
            if (dept.HasValue)
            {
                // if you not get Where then you need to add using system.Linq
                employees = employees.Where(e => e.Department == dept.Value);

            }
            return employees.GroupBy(e => e.Department).Select(g => new DeptHeadCount()
            {
                Department = g.Key.Value,
                Count = g.Count()
            }).ToList();
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            //return context.Employees;
            return context.Employees.FromSqlRaw<Employee>("Select * From Employees").ToList();
        }

        public Employee GetEmployee(int id)
        {
            SqlParameter parameter = new SqlParameter("@id", id);            
            return context.Employees.FromSqlRaw<Employee>("GetEmployeeByIds @id", parameter).ToList().FirstOrDefault();
            //retrive data by using store procedure
            //return context.Employees.FromSqlRaw<Employee>("GetEmployeeByIds {0}", id).ToList().FirstOrDefault();
            //return context.Employees.Find(id);
        }

        public IEnumerable<Employee> Search(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                return context.Employees;
            }
            return context.Employees.Where(e => e.Name.Contains(searchTerm)||e.Email.Contains(searchTerm));
        }

        public Employee Update(Employee employee)
        {
            var emp = context.Employees.Attach(employee);
            emp.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return employee;
        }
    }
}
