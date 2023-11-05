#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TESTASP_DCPR.Models
{
    public class Contravention
    {
        [Key]
        public int noFiche { get; set; }
        public Conducteur conducteur { get; set; }
        [ForeignKey("noDossier")]
        public string noDossier { get; set; }
        public string plaque { get; set; }
        public string typeVehicule { get; set; }
        public string couleur { get; set; }
        public string marque { get; set; }
        public Agents agent { get; set; }
        [ForeignKey("codeAgent")]
        public string codeAgent { get; set; }
        public string adresse { get; set; }
        public string articleViolation { get; set; }
        public int montantAPayer { get; set; }
        public DateTime dateContravention { get; set; }
        public string Statut { get; set; }
    }
}