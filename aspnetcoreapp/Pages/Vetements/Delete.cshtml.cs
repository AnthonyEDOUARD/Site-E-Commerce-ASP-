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
    public class DeleteModel : PageModel
    {
        private readonly aspnetcoreapp.Models.aspnetcoreappContext _context;

        public DeleteModel(aspnetcoreapp.Models.aspnetcoreappContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Vetement = await _context.Vetement.FindAsync(id);

            if (Vetement != null)
            {
                _context.Vetement.Remove(Vetement);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
