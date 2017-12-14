using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class MembershipType
    {
        [Required]
        public byte Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public short SignUpFee { get; set; }

        [Required]
        public byte DurationInMonths { get; set; }

        [Required]
        public byte DiscountRate { get; set; }

        public static readonly byte Unknown = 0;
        public static readonly byte PayAsYouGo = 1;
        public static readonly byte Monthly = 2;
        public static readonly byte Quarterly = 3;
        public static readonly byte Annual = 4;
    }
}
