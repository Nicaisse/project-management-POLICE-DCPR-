using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
#nullable disable

namespace TESTASP_DCPR.Models
{
    public class LoginModel
    {
        [Required]
        [EmailAddress]
        public String Email{ get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password{ get; set; }
        [Display(Name ="Remember Me")]
        public bool RememberMe{ get;set; }
    }

}