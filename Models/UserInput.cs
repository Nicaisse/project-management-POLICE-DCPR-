using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
#nullable disable

namespace TESTASP_DCPR.Models
{
    public class UserInput
    {
        
        public String codeAgent { get; set; }
        [Required]
        public String affectation { get; set; }
        [Required]
        public String nom { get; set; }
        [Required]
        public string prenom { get; set; }
        [Required]
        public String sexe { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "the password and confirmation password do not match")]
        public string ConfirmPassword { get; set; }






    }
}