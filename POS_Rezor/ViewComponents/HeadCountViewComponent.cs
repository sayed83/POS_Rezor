using Microsoft.AspNetCore.Mvc;
using POS_Rezor.Models;
using POS_Rezor.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POS_Rezor.ViewComponents
{
    public class HeadCountViewComponent : ViewComponent
    {
        private readonly IEmployeeRepository employeeRepository;

        public HeadCountViewComponent(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public IViewComponentResult Invoke(Dept? departmentName = null)
        {
            var result = employeeRepository.EmployeeCountByDept(departmentName);
            return View(result);
        }
        // public IViewComponentResult Invoke(Dept? department = null)
        //{
        //    var result = employeeRepository.EmployeeCountByDept(department);
        //    return View(result);
        //}

        //public IViewComponentResult Invoke()
        //{
        //    var result = employeeRepository.EmployeeCountByDept();
        //    return View(result);
        //}

    }
}
