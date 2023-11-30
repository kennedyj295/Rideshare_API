using Microsoft.AspNetCore.Identity;


namespace Rideshare_API.Entities
{
    public abstract class ApplicationUser : IdentityUser<int>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
    }
}