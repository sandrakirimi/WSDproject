using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Hotelone19301408.Data;
using Hotelone19301408.Models;
using Microsoft.Data.Sqlite;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace Hotelone19301408.Pages.Bookings
{
    public class CreateModel : PageModel
    {
        private readonly Hotelone19301408.Data.ApplicationDbContext _context;

        public CreateModel(Hotelone19301408.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["CEmail"] = new SelectList(_context.Customer, "Email", "Email");
            ViewData["RoomID"] = new SelectList(_context.Room, "ID", "ID");
            return Page();
        }

        [BindProperty]
        public Booking Booking { get; set; }
        public IList<Room> Vacancy { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            string _email = User.FindFirst(ClaimTypes.Name).Value;
            if (!ModelState.IsValid)
            {
                return Page();
            }
            ViewData["RoomID"] = new SelectList(_context.Room, "ID", "ID");


            var parameter1 = new SqliteParameter("@Room", Booking.RoomID);
            var parameter2 = new SqliteParameter("@CheckI", Booking.CheckIn);
            var parameter3 = new SqliteParameter("@CheckO", Booking.CheckOut);
            string query = "SELECT * From Room Where ID = @Room AND ID NOT IN (SELECT RoomID FROM Booking WHERE (CheckIn <= @CheckI AND CheckOut >= @CheckO) OR (CheckIn < @CheckO AND CheckOut >=@CheckO) OR (@CheckI <= CheckIn AND @CheckO >= CheckIn))";
            Vacancy = await _context.Room.FromSqlRaw(query, parameter1, parameter2, parameter3).ToListAsync();

            int VacancyCount = Vacancy.Count();
            if (VacancyCount == 1)
            {
                Booking bookingNew = new Booking();
                bookingNew.CheckIn = Booking.CheckIn;
                bookingNew.CheckOut = Booking.CheckOut;
                bookingNew.RoomID = Booking.RoomID;
                bookingNew.CustomerEmail = _email;


                var theRoom = await _context.Room.FindAsync(Booking.RoomID);
                var nights = ((Booking.CheckOut - Booking.CheckIn).Days);
                bookingNew.Cost = nights * theRoom.Price;
                _context.Booking.Add(bookingNew);
                await _context.SaveChangesAsync();

                ViewData["NewBooking"] = "true";
                ViewData["total"] = String.Format("{0:C}", bookingNew.Cost);
                ViewData["Rm"] = theRoom.ID;
                ViewData["BedC"] = theRoom.BedCount;
                ViewData["NightCount"] = nights;
            }
            else
            {
                ViewData["NewBooking"] = "false";
            }


            return Page();
        }
    }
}
