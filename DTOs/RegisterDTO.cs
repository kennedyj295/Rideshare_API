using System.ComponentModel.DataAnnotations;

namespace Rideshare_API.DTOs
{
    public class RegisterDTO
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [StringLength(12, MinimumLength = 6)]
        public string Password { get; set; }
    }
}
