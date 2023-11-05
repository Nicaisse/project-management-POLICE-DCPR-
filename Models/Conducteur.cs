#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TESTASP_DCPR.Models
{
    public class Conducteur
    {
        [Key]
        public string noDossier { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }

        public string sexe { get; set; }

        [Required]
        [Range(1000000000, 9999999999, ErrorMessage = "Le NIF doit comporter exactement 10 chiffres.")]
        public int nif { get; set; }
        public int compteur { get; set; }
    }
}