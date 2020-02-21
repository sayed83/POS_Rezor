using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using POS_Rezor.Models;
using POS_Rezor.Services;

namespace POS_Rezor.Pages.Employees
{
    public class DetailsModel : PageModel
    {
        private readonly IEmployeeRepository employeeRepository;

        public DetailsModel(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        [TempData]
        public string Message { get; set; }

        // [BindProperty(SupportsGet =true)]
        //public string Message { get; set; }

        public Employee Employee { get; private set; }
        //public void OnGet(int id = 1)
        //{
        //   Employee = employeeRepository.GetEmployee(id);
        //}
        public IActionResult OnGet(int id)
        {
           Employee = employeeRepository.GetEmployee(id);
            if(Employee == null)
            {
                return RedirectToPage("/NotFound");
            }
            return Page();
        }
    }
}