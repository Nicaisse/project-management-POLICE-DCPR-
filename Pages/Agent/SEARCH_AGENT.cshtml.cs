#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using TESTASP_DCPR.Models;

namespace TESTASP_DCPR.Pages.Agent
{
    public class SEARCH_AGENT : PageModel
    {
        private readonly db_context _context;

        public SEARCH_AGENT(db_context context)
        {
            _context = context;
        }
        public String rech { get; set; }
        public String search { get; set; }
        public List<Agents> rechech = new List<Agents>();
        public List<Contravention> searchC = new List<Contravention>();


        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            String search = Request.Form["rech"];
            bool n = _context.tab_agent.Any(p => p.codeAgent == search);
            if (!n)
            {
                ModelState.AddModelError(string.Empty, "code agent invalide");
            }
            else
            {
                searchC = _context.tab_contravention.Where(p => p.codeAgent == search).ToList();

                ModelState.AddModelError("codeAgent", "cet agent n'a pas encore emis de contravention");
            }


            return Page();
        }
    }
}