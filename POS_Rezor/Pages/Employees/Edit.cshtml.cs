using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using POS_Rezor.Models;
using POS_Rezor.Services;

namespace POS_Rezor.Pages.Employees
{
    public class EditModel : PageModel
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IWebHostEnvironment webHostEnvironment;

        public EditModel(IEmployeeRepository employeeRepository, IWebHostEnvironment webHostEnvironment)
        {
            this.employeeRepository = employeeRepository;
            this.webHostEnvironment = webHostEnvironment;
        }

        [BindProperty]
        public Employee Employee { get; set; }

        [BindProperty]
        public IFormFile Photo { get; set; }

        [BindProperty]
        public bool Notify { get; set; }
        public string Message { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id.HasValue)
            {
                Employee = employeeRepository.GetEmployee(id.Value);
            }
            else
            {
                Employee = new Employee();
            }

            if (Employee == null)
            {
                return RedirectToPage("/NotFound");
            }
            return Page();
        }

        public IActionResult OnPost(Employee employee)
        {
            if (ModelState.IsValid)
            {
                if (Photo != null)
                {
                    if (employee.PhotoPath != null)
                    {
                        string filepath = Path.Combine(webHostEnvironment.WebRootPath, "Images", employee.PhotoPath);
                        System.IO.File.Delete(filepath);
                    }
                    employee.PhotoPath = ProcessUploadFile();
                }
                if (Employee.Id > 0)
                {
                    Employee = employeeRepository.Update(employee);
                }
                else
                {
                    Employee = employeeRepository.Add(employee);
                }
                return RedirectToPage("Index");
            }
            return Page();
        }

        public IActionResult OnPostUpdateNotificationPreferences(int id)
        {
            if (Notify)
            {
                Message = "Thank you for turnig on notification";
            }
            else
            {
                Message = "You have Tourn off email notification";
            }

            TempData["message"] = Message;

            return RedirectToPage("Details", new { id = id });


            //return RedirectToPage("Details", new { id = id, message = Message });

            //thise line use when void because of IActionResult
            //Employee = employeeRepository.GetEmployee(id);
        }

        private string ProcessUploadFile()
        {
            string uniquefilename = null;
            if (Photo != null)
            {
                string uploadfolder = Path.Combine(webHostEnvironment.WebRootPath, "Images");
                uniquefilename = Guid.NewGuid().ToString() + "_" + Photo.FileName;
                string filepath = Path.Combine(uploadfolder, uniquefilename);
                using (var fileStrim = new FileStream(filepath, FileMode.Create))
                {
                    Photo.CopyTo(fileStrim);
                }
            }
            return uniquefilename;
        }

        //public IActionResult OnPost()
        //{

        //   Employee = employeeRepository.Update(Employee);
        //    return RedirectToPage("Index");
        //}


    }
}