using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using Hotelone19301408.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotelone19301408.Pages.Bookings
{
    [Authorize(Roles = "administrators")]
    public class CalcGomaStatsModel : PageModel
    {

        private readonly Hotelone19301408.Data.ApplicationDbContext _context;

        public CalcGomaStatsModel(Hotelone19301408.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<GomaStatistic> gomaStats { get; set; }
        
        public async Task<IActionResult> OngetAsync()
        {


            var CustomerGroups = _context.Customer.GroupBy(m => m.PostCode);

            gomaStats = await CustomerGroups.Select(g => new GomaStatistic { PostCode = g.Key, CustomerCount = g.Count() }).ToListAsync();
            return Page();
        
     
            /*{
                var BookingGroups = _context.Booking.GroupBy(m => m.RoomID);

                gomaStats = await BookingGroups.Select(g => new GomaStatistic { RoomID = g.Key, BookingCount = g.Count() }).ToListAsync();

            }*/

        }
    }
}

