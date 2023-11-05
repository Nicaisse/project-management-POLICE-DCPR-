using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TESTASP_DCPR.Models;

namespace TESTASP_DCPR.Pages_contravention
{
    public class IndexModel : PageModel
    {
        private readonly TESTASP_DCPR.Models.db_context _context;

        public IndexModel(TESTASP_DCPR.Models.db_context context)
        {
            _context = context;
        }

        public IList<Contravention> Contravention { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.tab_contravention != null)
            {
                Contravention = await _context.tab_contravention.ToListAsync();
            }
        }
    }
}
