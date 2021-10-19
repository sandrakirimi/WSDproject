using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Hotelone19301408.Models
{
    public class GomaStatistic
    {
        [Display(Name = "Number of Customers")]
        public int CustomerCount { get; set; }

        [Display(Name = "Number of Bookings")]
        public int BookingCount { get; set; }
        public int RoomID { get; internal set; }

        public string PostCode { get; set; }
    }
}
