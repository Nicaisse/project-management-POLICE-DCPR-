#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using TESTASP_DCPR.Models;

namespace TESTASP_DCPR.Pages.Dgi
{
    public class Etape1 : PageModel
    {
        private readonly db_context _context;

        public Etape1(db_context context)
        {
            _context = context;
        }
[BindProperty]
public int fiche { get; set; }
public bool test;
        public List<Contravention> Exist=new List<Contravention>();

        public void OnGet()
        {
           

        }
        
        public  IActionResult OnPost(){

            if (!ModelState.IsValid || _context.tab_dgi == null)
            {
                return Page();
            }
            bool fiche_exist = _context.tab_contravention.Any(x => x.noFiche == fiche);
            var montan_fiche = _context.tab_contravention.FirstOrDefault(a => a.noFiche == fiche);
          
            if (!fiche_exist){
                ModelState.AddModelError(string.Empty, "cette fiche n'existe pas");
                return Page();
            }else{

                if (montan_fiche.Statut == "P")
                {
                    ModelState.AddModelError(string.Empty, "cette fiche a deja ete entierement payer ");
                    return Page();
                }else if(montan_fiche.Statut=="BALANCE"){
                    ModelState.AddModelError(string.Empty, "cette fiche n'a pas ete entierement payer il reste un une balance de ");
                }
                Exist = _context.tab_contravention.Where(p => p.noFiche == fiche).ToList();


            }
          
            
            
            
            return Page();
        }

    }
}