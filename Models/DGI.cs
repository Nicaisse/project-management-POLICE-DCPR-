#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TESTASP_DCPR.Models
{
    public class DGI
    {
        public int id { get; set; }

        public Contravention contravention { get; set; }
        [ForeignKey("noFiche")]
        public string noFiche { get; set; }
        public int montant { get; set; }
        public string remarque { get; set; }
        public DateTime datePaiment { get; set; }
    }
}