using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using POS_Rezor.Models;
using POS_Rezor.Services;

namespace POS_Rezor.Pages.Expensess
{
    public class DeleteModel : PageModel
    {
        private readonly POS_Rezor.Services.AppDbContext _context;

        public DeleteModel(POS_Rezor.Services.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Expenses Expenses { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Expenses = await _context.Expensess
                .Include(e => e.Member).FirstOrDefaultAsync(m => m.ExpenceId == id);

            if (Expenses == null)
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

            Expenses = await _context.Expensess.FindAsync(id);

            if (Expenses != null)
            {
                _context.Expensess.Remove(Expenses);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
