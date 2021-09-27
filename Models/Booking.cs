using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Hotelone19301408.Models
{
    public class Booking
    {

        [Key, Required]
        public int ID { get; set; }

        [Display(Name ="Room ID")]
        public int RoomID { get; set; }

        [Display(Name ="Customer Email")]
        [DataType(DataType.EmailAddress)]
        public string CustomerEmail { get; set; }


        [DataType(DataType.Date)]
        [Display(Name ="Check In Date")]
        public DateTime CheckIn { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Check Out Date")]
        public DateTime CheckOut { get; set; }


        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Cost { get; set; }

        public Room TheRoom { get; set; }

        [Display(Name ="Customer Name")]
        public Customer TheCustomer { get; set; }
    }
}
