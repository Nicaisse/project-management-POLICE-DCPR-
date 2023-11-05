using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using TESTASP_DCPR.Models;
#nullable disable

namespace TESTASP_DCPR.Pages.Admin.users
{
    public class Login : PageModel
    {
        private readonly SignInManager<Agents> _signInManager;
     
        [BindProperty]
        public LoginModel Input { get; set; }


        public Login(SignInManager<Agents> signInManager)

        {
            _signInManager = signInManager;
        
        }


        

        public void OnGet()
        {
        }


        public async Task<IActionResult> OnPost()
        {
            if(ModelState.IsValid){
                var result = await _signInManager
                .PasswordSignInAsync(Input.Email
                ,Input.Password,Input.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded){
                   // _logger.LogInformation("Login successfully");

                    return RedirectToPage("/Index");
                }
                else{
                  //  _logger.LogInformation("Login failure");
                    ModelState.AddModelError(string.Empty, "Invalid Email or Password");
                }
           
           
           
           
            }
            return Page();
        }
    }
}