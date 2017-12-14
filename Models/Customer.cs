using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Customer
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please input customer's name.")]
        [StringLength(255, ErrorMessage = "Customer's name not longer than 255 characters.")]
        public string Name { get; set; }

        [Display(Name = "Date of Birth")]
        public DateTime? Birthday { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }
        
        public MembershipType MembershipType { get; set; }

        [Required(ErrorMessage = "Please choose Membership Type.")]
        [Min18YearsIfAMember]
        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }
    }
}
