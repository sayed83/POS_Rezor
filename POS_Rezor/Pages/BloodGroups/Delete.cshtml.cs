using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using POS_Rezor.Models;
using POS_Rezor.Services;

namespace POS_Rezor.Pages.BloodGroups
{
    public class DeleteModel : PageModel
    {
        private readonly POS_Rezor.Services.AppDbContext _context;

        public DeleteModel(POS_Rezor.Services.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public BloodGroup BloodGroup { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BloodGroup = await _context.BloodGroup.FirstOrDefaultAsync(m => m.BloodGroupId == id);

            if (BloodGroup == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BloodGroup = await _context.BloodGroup.FindAsync(id);

            if (BloodGroup != null)
            {
                _context.BloodGroup.Remove(BloodGroup);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
