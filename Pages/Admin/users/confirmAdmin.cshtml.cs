using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
#nullable disable

namespace TESTASP_DCPR.Pages.Admin.users
{
    public class confirmAdmin : PageModel
    {
        private readonly ILogger<confirmAdmin> _logger;

        public confirmAdmin(ILogger<confirmAdmin> logger)
        {
            _logger = logger;
        }
        [Required]
        public string username { get; set; }
        
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string p = "Admin";

        public String pass = "Admin@2023";




        public void OnGet()
        {
        }
        public IActionResult OnPost(){

            string z = Request.Form["username"];
            string x = Request.Form["password"];
            if (z==p && x==pass)
            {
                return RedirectToPage("./Register");

            }
            else{
                ModelState.AddModelError(string.Empty, "Invalid code or password");
            }


            return Page();
        }
    }
}