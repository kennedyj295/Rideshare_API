using Microsoft.AspNetCore.Identity;


namespace Rideshare_API.Entities
{
    public abstract class ApplicationUser : IdentityUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
    }
}
