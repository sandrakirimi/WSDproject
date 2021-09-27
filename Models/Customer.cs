using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotelone19301408.Models
{
    public class Customer
    {

        [Key, Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Email { get; set; }

        [Required]
        [MinLength(2), MaxLength(20)]
        [RegularExpression(@"^[a-zA-Z'-]*$", ErrorMessage = "Must onlt contain letters or ' -")]
        public string Surname { get; set; }

        [Required]
        [MinLength(2), MaxLength(20)]
        [RegularExpression(@"^[a-zA-Z'-]*$", ErrorMessage = "Must onlt contain letters or ' -")]
        [Display(Name ="Given Name")]
        public string GivenName { get; set; }


        [Required]
        [RegularExpression(@"^[0-9]{4}", ErrorMessage ="Must be a valid 4 digit post code")]
        public string PostCode { get; set; }

        public ICollection<Booking> TheBookings { get; set; }

        [NotMapped]
        [Display(Name = "Full Name")]
        public string FullName => $"{GivenName} {Surname}";
    }
}
