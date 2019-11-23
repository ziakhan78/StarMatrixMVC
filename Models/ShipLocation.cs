using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StarMatrix.Models
{
    public class ShipLocation
    {
        [Key]
        public int Id { get; set; }

        
        [Display(Name = "Tug Name")]
        public int TugId { get; set; }


        [ForeignKey("TugId")]
        public virtual Tug Tugs { get; set; }

        [Required]
        [Display(Name = "Present Location")]
        public string PresentLocation { get; set; }

        [Required]
        public string Availability { get; set; }

        [Required]
        [Display(Name = "Available Location")]
        public string AvailableLocation { get; set; }
               
        public string Ipaddress { get; set; }
      
        public DateTime? DateAdded { get; set; }
    }
}
