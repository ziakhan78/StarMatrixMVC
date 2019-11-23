using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StarMatrix.Models
{
    public class Towage
    {
        [Key]
        public int TowageId { get; set; }

        [Required]
        [Display(Name = "Departure Port")]
        public string DeparturePort { get; set; }
        
        [Required]
        [Display(Name = "Destination Port")]
        public string DestinationPort { get; set; }

        [Required]
        [Display(Name = "Estimated Displacement")]
        public string EstimatedDisplacement { get; set; }

        [Required]
        [Display(Name = "Towing Draft")]
        public string TowingDraft { get; set; }

        [Required]
        [Display(Name = "Dimensions")]
        public string Dimensions { get; set; }
        
        [Required]
        [Display(Name = "Estimated Laycan")]
        public string EstimatedLaycan { get; set; }

        [Required]
        [Display(Name = "Type of Tow")]
        public string TypeofTow { get; set; }

        [Required]
        [Display(Name = "Minimum BP Requirements")]
        public string MinimumBPRequirements { get; set; }
    }
}
