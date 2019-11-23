using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StarMatrix.Models
{
    public class Recycling
    {
        [Key]
        public int RecyclingId { get; set; }

        [Required]
        [Display(Name = "Type of Unit")]
        public string Typeofunit { get; set; }

        [Required]
        [Display(Name = "Estimated Ligthship")]
        public string EstimatedLigthship { get; set; }

        [Required]       
        public string Location { get; set; }

        public string LaidUp { get; set; }
        public string Status { get; set; }

        [Required]
        [Display(Name = "Delivery Laycan")]
        public string DeliveryLaycan { get; set; }

        [Required]      
        public string Dimensions { get; set; }

        [Required]
       
        public string HKC { get; set; }

      
    }
}
