using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Hotelone19301408.Models
{
    public class Room
    {

        [Key, Required]
        public int ID { get; set; }

        [Required]
        [RegularExpression(@"^[G1-3]{1}$", ErrorMessage ="Must be either G, 1, 2 or 3")]
        public string Level { get; set; }


        [RegularExpression(@"^[1-3]{1}$", ErrorMessage ="Number of the beds can range from 1-3")]
        [Display(Name ="Bed Count")]
        public int BedCount { get; set; }

        [Range(50,300)]
        [DisplayFormat(DataFormatString ="{0:C}")]
        public decimal Price { get; set; }

        public ICollection<Booking> TheBooking { get; set; }

    
    }
}
