using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Hotelone19301408.Models;

namespace Hotelone19301408.Pages.Customers
{
    public class MyDetailsModel : PageModel
    {

        private readonly Hotelone19301408.Data.ApplicationDbContext _context;

        public MyDetailsModel(Hotelone19301408.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CustomerViewModel Myself { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            string _email = User.FindFirst(ClaimTypes.Name).Value;
            Customer customer = await _context.Customer.FirstOrDefaultAsync(m => m.Email == _email);

            if (customer != null)
            {
                ViewData["ExistInDB"] = "true";
                Myself = new CustomerViewModel
                {
                    GivenName = customer.GivenName,
                    Surname = customer.Surname,
                    PostCode = customer.PostCode
                };
            }
            else
            {
                ViewData["ExistInDB"] = "fasle";
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            string _email = User.FindFirst(ClaimTypes.Name).Value;
            Customer customer = await _context.Customer.FirstOrDefaultAsync(m => m.Email == _email);

            if (customer != null)
            {
                ViewData["ExistInDB"] = "true";
            }
            else
            {
                ViewData["ExistInDB"] = "false";
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (customer == null)
            {
                customer = new Customer();
            }

            customer.Email = _email;
            customer.Surname = Myself.Surname;
            customer.GivenName = Myself.GivenName;
            customer.PostCode = Myself.PostCode;

            if ((string)ViewData["ExistInDB"] == "true")
            {
                _context.Attach(customer).State = EntityState.Modified;
            }
            else
            {
                _context.Customer.Add(customer);
            }
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            ViewData["SuccessDB"] = "true";
            return Page();


        }

/*        public void OnGet()
        {
        }*/
    }
}
