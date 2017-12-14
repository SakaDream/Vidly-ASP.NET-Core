using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Vidly.Models;

namespace Vidly.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please input movie's name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please input movie's release date.")]
        public DateTime ReleaseDate { get; set; }

        [Required(ErrorMessage = "Please input movie's date added.")]
        public DateTime DateAdded { get; set; }

        [Required(ErrorMessage = "Please input number in stock")]
        [Range(1, 20)]
        public short NumberInStock { get; set; }

        public Genre Genre { get; set; }

        [Required(ErrorMessage = "Please choose a genre.")]
        public byte GenreId { get; set; }
    }
}
