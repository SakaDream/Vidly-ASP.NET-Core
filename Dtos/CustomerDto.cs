using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Dtos
{
    public class CustomerDto
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please input customer's name.")]
        [StringLength(255, ErrorMessage = "Customer's name not longer than 255 characters.")]
        public string Name { get; set; }

        public DateTime? Birthday { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public MembershipTypeDto MembershipType { get; set; }

        [Required(ErrorMessage = "Please choose Membership Type.")]
        public byte MembershipTypeId { get; set; }
    }
}
