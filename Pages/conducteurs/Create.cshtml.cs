
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TESTASP_DCPR.Models;

namespace TESTASP_DCPR.Pages.conducteurs
{
    public class CreateModel : PageModel
    {
        private readonly TESTASP_DCPR.Models.db_context _context;

        public CreateModel(TESTASP_DCPR.Models.db_context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Conducteur Conducteur { get; set; } = default!;
      
public async Task<IActionResult> OnPostAsync()
        {
                            if (!ModelState.IsValid || _context.tab_conducteur == null || Conducteur == null)
                                {
                                    return Page();
                                }



           
            
                           foreach(var p in _context.tab_conducteur)
                           {
                            
                                if(p.nif==Conducteur.nif){
                            ModelState.AddModelError("nom","Ce nif est deja dans le Systeme verifier votre nif"); 
                                        return Page();
                                }
                            }    
                            
             

             //pour generer le code a partire du niom du prenom et 4 premiere numero du nif
            string n=Conducteur.nif.ToString();
            
            // if(Conducteur.nif<999999999){
            //     ModelState.AddModelError("nom","le nif doit comprendre 10chiffre");
            //     return Page();
            // }
         
            Conducteur.noDossier=Conducteur.nom.Substring(0,2)+Conducteur.prenom.Substring(0,2)+n.Substring(0,2)+n.Substring(n.Length-2,2);
            
           Conducteur.compteur=0;
         
            _context.tab_conducteur.Add(Conducteur);
            await _context.SaveChangesAsync();

            return RedirectToPage("./SERVICE_AGENT");
        }
    }
}
