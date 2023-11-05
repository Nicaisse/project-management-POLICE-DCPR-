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
    public class SEARCH_YEAR : PageModel
    {
        private readonly db_context _context;

        public SEARCH_YEAR(db_context context)
        {
            _context = context;
        }
        [BindProperty]
        public int rech { get; set; }
        public List<Agents> rechech = new List<Agents>();
        public string search { get; set; }
        [BindProperty]
        public int rechdat{get;set;}
        public string DATO { get; set; }
    public List<Contravention> searchC = new List<Contravention>();



        public void OnGet()
        {

            // String rech=Request.Form["rech"];
            // rechech=_context.tab_agent.Where(p => p.codeAgent==rech).ToList();
        }
        public IActionResult OnPost()
        {
               


          foreach(var n in _context.tab_conducteur){
            if(n.nif==rech){
                    search = n.noDossier;
                }

          }
          if(search==null){
                ModelState.AddModelError(string.Empty, "ce nif n'existe pas dans le systeme");
            }else{
           
            searchC = _context.tab_contravention.Where(p => p.noDossier == search && p.dateContravention.Year==rechdat).ToList();

            if(searchC.Count==0){
                ModelState.AddModelError(string.Empty,"ce conducteur n'a pas de contravention pour cette annee");
            }
            }



            return Page();
        }

    }
}