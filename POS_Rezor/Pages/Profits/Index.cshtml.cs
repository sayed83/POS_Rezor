﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using POS_Rezor.Models;
using POS_Rezor.Services;

namespace POS_Rezor.Pages.Profits
{
    public class IndexModel : PageModel
    {
        private readonly POS_Rezor.Services.AppDbContext _context;

        public IndexModel(POS_Rezor.Services.AppDbContext context)
        {
            _context = context;
        }

        public IList<Profit> Profit { get;set; }

        public async Task OnGetAsync()
        {
            Profit = await _context.Profits
                .Include(p => p.Invest).ToListAsync();
        }
    }
}
