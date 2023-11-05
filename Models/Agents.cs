#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;


namespace TESTASP_DCPR.Models
{
    public class Agents :IdentityUser
    {
     
        [Required]
        [EmailAddress]
        override
        public string Email{ get; set; }

        // [Required]
        // [DataType(DataType.Password)]
        // public string Password{ get; set; }
        // [Required]
        // [DataType(DataType.Password)]
        // [Compare("Password",ErrorMessage ="the password and confirmation password do not match")]
        // public string ConfirmPassword{ get; set; }

        public String codeAgent { get; set; }
        [Required]
        public String affectation { get; set; }
        public String nom { get; set; }
        public string prenom { get; set; }
        public bool isauthor { get; set; } = false;
        public String sexe { get; set; }
        
       
        
    }
}