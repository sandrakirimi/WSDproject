using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Hotelone19301408.Data;
using Hotelone19301408.Models;

namespace Hotelone19301408.Pages.Rooms
{
    public class IndexModel : PageModel
    {
        private readonly Hotelone19301408.Data.ApplicationDbContext _context;

        public IndexModel(Hotelone19301408.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Room> Room { get;set; }

        public async Task OnGetAsync()
        {
            Room = await _context.Room.ToListAsync();
        }
    }
}
