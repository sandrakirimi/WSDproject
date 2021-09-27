using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Hotelone19301408.Models;

namespace Hotelone19301408.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Hotelone19301408.Models.Customer> Customer { get; set; }
        public DbSet<Hotelone19301408.Models.Booking> Booking { get; set; }
        public DbSet<Hotelone19301408.Models.Room> Room { get; set; }
    }
}
