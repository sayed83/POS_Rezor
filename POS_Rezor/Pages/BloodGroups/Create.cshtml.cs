using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using POS_Rezor.Models;
using POS_Rezor.Services;

namespace POS_Rezor.Pages.BloodGroups
{
    public class CreateModel : PageModel
    {
        private readonly POS_Rezor.Services.AppDbContext _context;

        public CreateModel(POS_Rezor.Services.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public BloodGroup BloodGroup { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.BloodGroup.Add(BloodGroup);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
