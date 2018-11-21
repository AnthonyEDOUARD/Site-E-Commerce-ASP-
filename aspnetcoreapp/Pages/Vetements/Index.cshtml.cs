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
    public class IndexModel : PageModel
    {
        private readonly aspnetcoreapp.Models.aspnetcoreappContext _context;

        public IndexModel(aspnetcoreapp.Models.aspnetcoreappContext context)
        {
            _context = context;
        }

        public IList<Vetement> Vetement { get;set; }

        public async Task OnGetAsync()
        {
            Vetement = await _context.Vetement.ToListAsync();
        }
    }
}
