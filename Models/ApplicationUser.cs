using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Vidly.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [StringLength(255)]
        public string DrivingLicense { get; set; }

        [Required]
        [StringLength(50)]
        public string Phone { get; set; }
    }
}
