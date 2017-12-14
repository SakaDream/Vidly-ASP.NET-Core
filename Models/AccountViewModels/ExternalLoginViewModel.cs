using System.ComponentModel.DataAnnotations;

namespace Vidly.Models.AccountViewModels
{
    public class ExternalLoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Driving License")]
        public string DrivingLicense { get; set; }

        [Required]
        [StringLength(50)]
        public string Phone { get; set; }
    }
}
