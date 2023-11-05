#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using TESTASP_DCPR.Models;

namespace TESTASP_DCPR.Pages.Admin.users
{
    public class Register : PageModel
    {
        [BindProperty]
        public UserInput Input { get; set; }
        private readonly UserManager<Agents> _userManager;
        private readonly ILogger<Register> _logger;
        private readonly IMapper _mapper;
        public Register(UserManager<Agents> userManager,IMapper mapper,ILogger<Register> logger )
        {
          _userManager = userManager;
          _mapper = mapper;
          _logger = logger;
        }

        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost(){
                if(ModelState.IsValid){
                Input.codeAgent = Input.nom.Substring(0, 3) + Input.prenom.Substring(0, 3) + Input.affectation.Substring(0, 2);

                Agents user = _mapper.Map<Agents>(Input);
                user.UserName = Input.Email;
                var res = await _userManager.CreateAsync(user, Input.Password);
                if(res.Succeeded){
                    _logger.LogInformation("Account created successfully");
                    return RedirectToPage("/Index");
                }else{
                    _logger.LogInformation("Account not create");
                    ModelState.AddModelError(string.Empty, "Account not create because this account already exist");
                    return Page();
                }
            }


            return Page();
        }
    }
}