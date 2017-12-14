using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Genre
    {
        [Required]
        public byte Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
