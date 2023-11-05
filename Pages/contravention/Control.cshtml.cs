#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using TESTASP_DCPR.Models;

namespace TESTASP_DCPR.Pages.contravention
{
    public class Control : PageModel
    {
        private readonly db_context _context;

        public Control(db_context context)
        {
            _context = context;
        }
        [BindProperty]
        public int rech { get; set; }
         
          public int search { get; set; }
            public List<Conducteur> searchC=new List<Conducteur>();
            public bool nif_exist;
        public string test;
        public bool test2=false;
        // public List<Contravention> test2 = new List<Contravention>();


        public void OnGet()
        {
            
            

        }
         public IActionResult OnPost()
        {
           
            if (!ModelState.IsValid || _context.tab_conducteur == null )
                                {
                                    return Page();
                                }
         

           
                 
                 nif_exist=_context.tab_conducteur.Any(x=> x.nif==rech);

           
                if(!nif_exist){
                    ModelState.AddModelError(string.Empty,"ce nif n'est pas dans le systeme");
                    // return RedirectToPage("/conducteurs/Create");
                }
                    
                    
        
                    int d=rech;
                    String y=rech.ToString();

                    foreach(var p in _context.tab_conducteur){
                        int b=p.nif;
                        String v=b.ToString();
                        if(v==y){
                            
                            searchC.Add(p);
                    test = p.noDossier;
                }
              }

            var n = _context.tab_contravention.Where(p => p.noDossier == test);
            foreach(var p in n){
                if(p.Statut!="P"){
                    test2 = false;
                    ModelState.AddModelError(string.Empty, "le conducteur n'a pas encore paye toutes ses contraventions precedentes");
                }else{
                    test2 = true;
                }
            }

            return Page();
        }
}
}