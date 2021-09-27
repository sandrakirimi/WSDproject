using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Hotelone19301408.Models
{
    public class SearchViewModel
    {
        [Display(Name = "Check In Date")]
        [DataType(DataType.Date)]
        public DateTime CheckIn { get; set; }

        [Display(Name = "Check Out Date")]
        [DataType(DataType.Date)]
        public DateTime CheckOut { get; set; }

        [RegularExpression(@"[1-3]{1}")]
        [Display(Name = "Bed Count")]
        public int BedCount { get; set; }
    }
}
