using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Rideshare_API.Entities;

namespace Rideshare_API.Controllers
{
    public class AccountController
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AccountController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        


    }
}
