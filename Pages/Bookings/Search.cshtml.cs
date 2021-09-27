
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Hotelone19301408.Models;

namespace Hotelone19301408.Pages.Bookings
{
    public class SearchModel : PageModel
    {
        private readonly Hotelone19301408.Data.ApplicationDbContext _context;

        public SearchModel(Hotelone19301408.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SearchViewModel search { get; set; }
        public IList<Room> Rooms { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            var parameter1 = new SqliteParameter("@BedC", search.BedCount);
            var parameter2 = new SqliteParameter("@CheckI", search.CheckIn);
            var parameter3 = new SqliteParameter("@CheckO", search.CheckOut);
            string query = "SELECT * From Room Where BedCount = @BedC AND ID NOT IN (SELECT RoomID FROM Booking WHERE (CheckIn <= @CheckI AND CheckOut >= @CheckO) OR (CheckIn < @CheckO AND CheckOut >=@CheckO) OR (@CheckI <= CheckIn AND @CheckO >= CheckIn))";
            
            Rooms = await _context.Room.FromSqlRaw(query, parameter1, parameter2, parameter3).ToListAsync();
            ViewData["SuccessDB"] = "true";
            return Page();
        }
    }
}
