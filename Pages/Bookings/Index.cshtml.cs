using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Hotelone19301408.Data;
using Hotelone19301408.Models;
using System.Security.Claims;

namespace Hotelone19301408.Pages.Bookings
{
    public class IndexModel : PageModel
    {
        private readonly Hotelone19301408.Data.ApplicationDbContext _context;

        public IndexModel(Hotelone19301408.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Booking> Booking { get;set; }

        public async Task OnGetAsync(string sortOrder)
        {
            string _email = User.FindFirst(ClaimTypes.Name).Value;
            ViewData["Email"] = _email;
            if (String.IsNullOrEmpty(sortOrder))
            {
                sortOrder = "price_asc";
            }
            
            Customer customer = await _context.Customer.FirstOrDefaultAsync(m => m.Email == _email);
            var booking = (IQueryable<Booking>)_context.Booking;

            switch (sortOrder)
            {
                case "price_asc":
                    booking = booking.Include(p => p.TheCustomer).Include(p => p.TheRoom).Where(m => m.CustomerEmail == _email).OrderBy(m => (double)m.Cost);
                    break;
                case "price_desc":
                    booking = booking.Include(p => p.TheCustomer).Include(p => p.TheRoom).Where(m => m.CustomerEmail == _email).OrderByDescending(m => (double)m.Cost);
                    break;
                case "CheckI_asc":
                    booking = booking.Include(p => p.TheCustomer).Include(p => p.TheRoom).Where(m => m.CustomerEmail == _email).OrderBy(m => m.CheckIn);
                    break;
                case "CheckI_desc":
                    booking = booking.Include(p => p.TheCustomer).Include(p => p.TheRoom).Where(m => m.CustomerEmail == _email).OrderByDescending(m => m.CheckIn);
                    break;
            }
            ViewData["PriceOrder"] = sortOrder != "price_desc" ? "price_desc" : "price_asc";
            ViewData["CheckInPriceOrder"] = sortOrder != "CheckI_desc" ? "CheckI_desc" : "CheckI_asc";
            Booking = await booking.AsNoTracking().Include(a => a.TheCustomer).Include(b => b.TheRoom).ToListAsync();
        }
    }
}
