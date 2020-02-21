using POS_Rezor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POS_Rezor.Services
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _Employees;
        public MockEmployeeRepository()
        {
            _Employees = new List<Employee>()
            {
                new Employee {Id = 1, Name = "Sayed", Department= Dept.HR, PhotoPath = "sayed.png", Email = "mdsayed83@gmail.com"},
                new Employee {Id = 2, Name = "Mizan", Department= Dept.Payroll, PhotoPath = "mizan.png", Email = "mizan@gmail.com"},
                new Employee {Id = 3, Name = "Hasan", Department= Dept.IT, PhotoPath = "hasan.png", Email = "hasan@gmail.com"}
            };
        }

        public Employee Add(Employee newEmployee)
        {
            newEmployee.Id = _Employees.Max(e => e.Id) + 1;
            _Employees.Add(newEmployee);
            return newEmployee;
        }

        public Employee Delete(int id)
        {
            Employee employeeToDelete = _Employees.FirstOrDefault(e => e.Id == id);
            if (employeeToDelete != null)
            {
                _Employees.Remove(employeeToDelete);
            }
            return employeeToDelete;
        }
        public IEnumerable<DeptHeadCount> EmployeeCountByDept(Dept? dept)
        {
            IEnumerable<Employee> quary = _Employees;
            if (dept.HasValue)
            {
                quary = quary.Where(e => e.Department == dept.Value);
            }
            return quary.GroupBy(e => e.Department).Select(g => new DeptHeadCount()
            {
                Department = g.Key.Value,
                Count = g.Count()
            }).ToList();

        }
        //public IEnumerable<DeptHeadCount> EmployeeCountByDept()
        //{
        //    return _Employees.GroupBy(e => e.Department).Select(g => new DeptHeadCount()
        //    {
        //        Department = g.Key.Value,
        //        Count = g.Count()
        //    }).ToList();
        //}

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _Employees;
        }

        public Employee GetEmployee(int id)
        {
            return _Employees.FirstOrDefault(e => e.Id == id);
        }


        public IEnumerable<Employee> Search(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                return _Employees;
            }
            return _Employees.Where(e => e.Name.Contains(searchTerm)||e.Email.Contains(searchTerm));
        }

        public Employee Update(Employee employee)
        {
            Employee emp = _Employees.FirstOrDefault(e => e.Id == employee.Id);

            emp.Name = employee.Name;
            emp.Email = employee.Email;
            emp.Department = employee.Department;
            emp.PhotoPath = employee.PhotoPath;

            return emp;
        }
    }
}
