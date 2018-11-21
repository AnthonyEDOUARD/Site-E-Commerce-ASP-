using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using aspnetcoreapp.Models;

namespace aspnetcoreapp.Pages.Vetements
{
    public class DetailsModel : PageModel
    {
        private readonly aspnetcoreapp.Models.aspnetcoreappContext _context;

        public DetailsModel(aspnetcoreapp.Models.aspnetcoreappContext context)
        {
            _context = context;
        }

        public Vetement Vetement { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Vetement = await _context.Vetement.FirstOrDefaultAsync(m => m.ID == id);

            if (Vetement == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
