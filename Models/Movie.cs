using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please input movie's name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please input movie's release date.")]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Required(ErrorMessage = "Please input movie's date added.")]
        [Display(Name = "Date Added")]
        public DateTime DateAdded { get; set; }

        [Required(ErrorMessage = "Please input number in stock")]
        [Range(0, 32767)]
        [Display(Name = "Number In Stock")]
        public short NumberInStock { get; set; }

        public Genre Genre { get; set; }

        [Required(ErrorMessage = "Please choose a genre.")]
        [Display(Name = "Genre")]
        public byte GenreId { get; set; }
    }
}
