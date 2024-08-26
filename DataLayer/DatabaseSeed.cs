using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using DataLayer.Models;
using Microsoft.AspNetCore.Identity;

namespace DataLayer
{
    public class DatabaseSeed
    {
        private static UserManager<User> _userManager;
        private static RoleManager<IdentityRole> _roleManager;

        public static async Task SeedAsync(ApplicationContext context, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;

            // Ensure the database is created and migrated
            context.Database.Migrate();

            // Perform seeding
            await EnsureCreatedAsync();
        }

        private static async Task EnsureCreatedAsync()
        {
            try
            {
                string[] roleNames = { "Customer", "Admin" };
                foreach (var roleName in roleNames)
                {
                    var roleExist = await _roleManager.RoleExistsAsync(roleName);
                    if (!roleExist)
                    {
                        await _roleManager.CreateAsync(new IdentityRole(roleName));
                    }
                }

                var adminUser = await _userManager.FindByEmailAsync("admin@example.com");
                if (adminUser == null)
                {
                    adminUser = new User
                    {
                        UserName = "admin",
                        FirstName = "admin",
                        LastName = "admin",
                        Email = "admin@example.com"
                    };

                    var result = await _userManager.CreateAsync(adminUser, "Admin@123");
                    if (result.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(adminUser, "Admin");
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception (replace with a logger in production)
                Console.WriteLine(ex);
            }
        }
    }
}
