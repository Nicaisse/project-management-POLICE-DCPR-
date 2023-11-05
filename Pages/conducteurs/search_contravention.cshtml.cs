#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using TESTASP_DCPR.Models;

namespace TESTASP_DCPR.Pages.conducteurs
{
    public class search_contravention : PageModel
    {
        private readonly db_context _context;

        public search_contravention(db_context context)
        {
            _context = context;
        }
        [BindProperty]
        public DateTime rech { get; set; }

        public DateTime search { get; set; }
        public List<Contravention> searchC = new List<Contravention>();
        public List<Conducteur> searchA = new List<Conducteur>();
        [BindProperty]
        public string selectaction { get; set; }
        public int Year { get; set; }
        [BindProperty]
        public int nif { get; set; }










        public void OnGet()
        {

            // String rech=Request.Form["rech"];
            // rechech=_context.tab_agent.Where(p => p.codeAgent==rech).ToList();
        }
        public IActionResult OnPost(String Action)
        {
            selectaction = Action;

            DateTime d = rech;
            String y = rech.ToString("dd-MM-yyyy");

            //Console.WriteLine(y);

            foreach (var p in _context.tab_contravention)
            {
                DateTime b = p.dateContravention;
                String v = b.ToString("dd-MM-yyyy");
                Console.WriteLine(v);
                if (v == y)
                {
                    searchC.Add(p);
                }
            }
            if (searchC.Count == 0)
            {
                ModelState.AddModelError(string.Empty, "pas de contravention  cette date");
            }


            return Page();

        }
    }

}
