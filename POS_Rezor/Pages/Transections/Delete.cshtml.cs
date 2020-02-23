using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using POS_Rezor.Models;
using POS_Rezor.Services;

namespace POS_Rezor.Pages.Transections
{
    public class DeleteModel : PageModel
    {
        private readonly POS_Rezor.Services.AppDbContext _context;

        public DeleteModel(POS_Rezor.Services.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Transection Transection { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Transection = await _context.Transections
                .Include(t => t.Member).FirstOrDefaultAsync(m => m.TransectionId == id);

            if (Transection == null)
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

            Transection = await _context.Transections.FindAsync(id);

            if (Transection != null)
            {
                _context.Transections.Remove(Transection);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
