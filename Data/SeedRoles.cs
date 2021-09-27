using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Hotelone19301408.Models;

namespace Hotelone19301408.Data
{
    public class SeedRoles
    {
        public static async Task CreateRoles (IServiceProvider serviceProvide, IConfiguration configuration)
        {
            var RoleManager = serviceProvide.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvide.GetRequiredService<UserManager<IdentityUser>>();

            string[] roleNames = { "administrators", "customers" };
            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                // check whether the role already exists
                var roleExist = await RoleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    // creating the roles
                    roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            // Creating an admin user who will maintain the web app
            // His/her username are read from the configuration file: appsettings.json
            var poweruser = new IdentityUser
            {
                UserName = configuration.GetSection("UserSettings")["UserEmail"],
                Email = configuration.GetSection("UserSettings")["UserEmail"]
            };

            string userPassword = configuration.GetSection("UserSettings")["UserPassword"];
            var user = await UserManager.FindByEmailAsync(configuration.GetSection("UserSettings")["UserEmail"]);
            // if this admin user doesn't exist in the database, ​create it in the database;
            // otherwise, do nothing.
            if (user == null)
            {
                var createPowerUser = await UserManager.CreateAsync(poweruser, userPassword);
                if (createPowerUser.Succeeded)
                {
                    // here we assign the new user the "Admin" role 
                    await UserManager.AddToRoleAsync(poweruser, "administrators");
                }
            }
        }
    }
}
