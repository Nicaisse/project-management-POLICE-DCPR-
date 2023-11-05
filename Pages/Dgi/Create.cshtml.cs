#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TESTASP_DCPR.Models;

namespace TESTASP_DCPR.Pages_Dgi
{
    public class CreateModel : PageModel
    {
        private readonly TESTASP_DCPR.Models.db_context _context;

        public CreateModel(TESTASP_DCPR.Models.db_context context)
        {
            _context = context;
        }
            [BindProperty]
        public Contravention Contravention{ get; set; }
        
        

        public IActionResult OnGet(int id)
        {
           
            // if (id == 0 || _context.tab_contravention == null)
            // {
            //     return NotFound();
            // }

            var contravention = _context.tab_contravention.FirstOrDefault(m => m.noFiche== id);
            if (contravention == null)
            {
                return NotFound();
            }
            
            Contravention=contravention;
            return Page();
        }

        [BindProperty]
        public DGI DGI { get; set; } = default!;
        [BindProperty]
        public int N { get; set; }
        
        
        public string i;
        
        
    
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.tab_dgi == null || DGI == null)
            {
                return Page();
            }
            
            // bool fiche_exist=_context.tab_contravention.Any(x=> x.noFiche==N);
            var montan_fiche=_context.tab_contravention.FirstOrDefault(a => a.noFiche==Contravention.noFiche);
            
                 
                
                       
                        if(montan_fiche.Statut=="P"){
                              ModelState.AddModelError(string.Empty,"cette fiche a deja ete payer ");
                                return Page();
                        }
                         if(montan_fiche.montantAPayer!=Contravention.montantAPayer){
                                 ModelState.AddModelError(string.Empty,"ce montant ne corresppond pas au montant a payer sur la fiche ");
                                return Page();
                        }
                

             
            if (montan_fiche != null)
                    {
                        montan_fiche.Statut = "P"; // Modifier le statut
                        
                         // Sauvegarder les modifications dans la base de données
                    }



                // foreach(var p in _context.tab_contravention){
                //             if(p.noFiche==N){
                //                  i=N.ToString();
                                 
                               
                                
                //             }
                //     }

                DGI.noFiche = Contravention.noFiche.ToString();

            DGI.montant = Contravention.montantAPayer;
                          
                          DGI.datePaiment=DateTime.Now;
                       _context.tab_dgi.Add(DGI);
                    await _context.SaveChangesAsync();

                          return RedirectToPage("./Index");
        }
    }
}
