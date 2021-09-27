using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Hotelone19301408.Models
{
    public class CustomerViewModel
    {
        [Required]
        [RegularExpression(@"^[a-zA-Z'-]*$", ErrorMessage = "Please enter a valid last name with either letters, apostrophe or hyphen.")]
        [MinLength(2), MaxLength(20)]
        [Display(Name = "Given Name")]
        public string GivenName { get; set; }


        [Required]
        [MinLength(2), MaxLength(20)]
        [RegularExpression(@"^[a-zA-Z'-]*$", ErrorMessage = "Please enter a valid last name with either letters, apostrophe or hyphen.")]
        public string Surname { get; set; }


        [Required]
        [RegularExpression(@"^[0-9]{4}", ErrorMessage = "Must be a valid 4 digit post code")]
        public string PostCode { get; set; }

    }
}
