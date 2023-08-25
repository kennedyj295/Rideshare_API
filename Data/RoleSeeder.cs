using Microsoft.AspNetCore.Identity;

namespace Rideshare_API.Data
{
    public class RoleSeeder
    {
        public static async Task SeedRoles(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            if (!await roleManager.RoleExistsAsync("Driver"))
            {
                await roleManager.CreateAsync(new IdentityRole("Driver"));
            }

            if (!await roleManager.RoleExistsAsync("Rider"))
            {
                await roleManager.CreateAsync(new IdentityRole("Rider"));
            }
        }
    }
}
