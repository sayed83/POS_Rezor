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

namespace POS_Rezor.Pages.Invests
{
    public class EditModel : PageModel
    {
        private readonly POS_Rezor.Services.AppDbContext _context;

        public EditModel(POS_Rezor.Services.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Invest Invest { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Invest = await _context.Invests
                .Include(i => i.Member).FirstOrDefaultAsync(m => m.InvestId == id);

            if (Invest == null)
            {
                return NotFound();
            }
           ViewData["MemberId"] = new SelectList(_context.Members, "MemberId", "MemberName");
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

            _context.Attach(Invest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvestExists(Invest.InvestId))
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

        private bool InvestExists(int id)
        {
            return _context.Invests.Any(e => e.InvestId == id);
        }
    }
}
