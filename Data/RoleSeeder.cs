using Microsoft.AspNetCore.Identity;
using Rideshare_API.Entities;

namespace Rideshare_API.Data
{
    public class RoleSeeder
    {
        public static async Task SeedRoles(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole<int>>>();

            if (!await roleManager.RoleExistsAsync("Driver"))
            {
                await roleManager.CreateAsync(new IdentityRole<int>("Driver"));
            }

            if (!await roleManager.RoleExistsAsync("Rider"))
            {
                await roleManager.CreateAsync(new IdentityRole<int>("Rider"));
            }
        }
    }
}
