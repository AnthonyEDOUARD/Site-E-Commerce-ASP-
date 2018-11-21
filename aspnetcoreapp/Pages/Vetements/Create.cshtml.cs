using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using aspnetcoreapp.Models;

namespace aspnetcoreapp.Pages.Vetements
{
    public class CreateModel : PageModel
    {
        private readonly aspnetcoreapp.Models.aspnetcoreappContext _context;

        public CreateModel(aspnetcoreapp.Models.aspnetcoreappContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Vetement Vetement { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Vetement.Add(Vetement);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}