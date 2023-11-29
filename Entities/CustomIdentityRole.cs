using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;


namespace Rideshare_API.Entities
{
    [Table("Roles")]
    public class CustomIdentityRole : IdentityRole
    {
        public CustomIdentityRole() : base()
        {
        }

        public CustomIdentityRole(string roleName) : base(roleName)
        {
        }
    }
}
