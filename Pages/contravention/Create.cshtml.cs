#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TESTASP_DCPR.Models;
using Microsoft.Identity;
using Microsoft.AspNetCore.Identity;

namespace TESTASP_DCPR.Pages_contravention
{
    public class CreateModel : PageModel
    {
        private readonly TESTASP_DCPR.Models.db_context _context;
        private readonly UserManager<Agents> _usermanager;


        public CreateModel(TESTASP_DCPR.Models.db_context context,UserManager<Agents> userManager)
        {
            _usermanager = userManager;
            _context = context;
           
        }
    
        public List<Agents> selectagent{get;set;}=default!;
        public List<Conducteur> selectcon{get;set;}=default!;
        public string IdUser{ get; set; }
        public string codeAgent { get; set; }
        
        



        public Conducteur searchC;
       [BindProperty]
        public Conducteur Conducteur { get; set; } = default!;
       
        public async Task<IActionResult> OnGet(string id)
        {
            if(User.Identity.IsAuthenticated){
                var UserId = _usermanager.GetUserId(User);
                var recup = await _usermanager.FindByIdAsync(UserId);
                codeAgent = recup.codeAgent;

            }
              if (_context.tab_agent != null)
            {
                selectagent = _context.tab_agent.ToList();
                
            }
            if (id == null || _context.tab_conducteur == null)
            {
                return NotFound();
            }

            var conducteur = _context.tab_conducteur.FirstOrDefault(m => m.noDossier == id);
            if (conducteur == null)
            {
                return NotFound();
            }
            Conducteur = conducteur;
            return Page();
        }

        [BindProperty]

        public Contravention kontravention { get; set; } = default!;



        public IActionResult OnPost()
        {


            


            kontravention.Statut="non-paye";
            kontravention.noDossier=Conducteur.noDossier;
            kontravention.dateContravention=DateTime.Now;

            _context.tab_contravention.Add(kontravention);
            var update = _context.tab_conducteur.FirstOrDefault(e => e.nif == Conducteur.nif);
            if (update != null)
            {
                update.compteur = update.compteur + 1;
                _context.SaveChanges();
            }
             _context.SaveChangesAsync();
           




            return RedirectToPage("./Index");
        
            
          
        }
    }
}
