using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using POS_Rezor.Models;
using POS_Rezor.Services;

namespace POS_Rezor.Pages.Profits
{
    public class EditModel : PageModel
    {
        private readonly POS_Rezor.Services.AppDbContext _context;

        public EditModel(POS_Rezor.Services.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Profit Profit { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Profit = await _context.Profits
                .Include(p => p.Invest).FirstOrDefaultAsync(m => m.ProfitId == id);

            if (Profit == null)
            {
                return NotFound();
            }
           ViewData["InvestId"] = new SelectList(_context.Invests, "InvestId", "InvestPurpose");
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Profit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfitExists(Profit.ProfitId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ProfitExists(int id)
        {
            return _context.Profits.Any(e => e.ProfitId == id);
        }
    }
}
