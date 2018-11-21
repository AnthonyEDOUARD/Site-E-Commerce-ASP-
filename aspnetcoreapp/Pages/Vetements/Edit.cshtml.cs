using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using aspnetcoreapp.Models;

namespace aspnetcoreapp.Pages.Vetements
{
    public class EditModel : PageModel
    {
        private readonly aspnetcoreapp.Models.aspnetcoreappContext _context;

        public EditModel(aspnetcoreapp.Models.aspnetcoreappContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Vetement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VetementExists(Vetement.ID))
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

        private bool VetementExists(int id)
        {
            return _context.Vetement.Any(e => e.ID == id);
        }
    }
}
