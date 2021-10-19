using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Hotelone19301408.Models
{
      public class BookingViewModel
    {
        [Required]
        public int RoomID { get; set; }
        [Required]
        [Display(Name = "Number of bookings")]
        public int BookingCount { get; set; }
        [Required]
        public string PostCode { get; set; }
        [Display(Name = "Number of customers")]
        public int CustomerCount { get; set; }

    }
}
