using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vidly.Data;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/NewRental")]
    public class NewRetalController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NewRetalController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IActionResult CreateNewRentail(NewRentalDto newRentalDto)
        {
            if (newRentalDto.MovieIds.Count == 0)
                return BadRequest("No Movie Ids have been given.");

            var customer = _context.Customers.Single(c => c.Id == newRentalDto.CustomerId);

            if (customer == null)
                return BadRequest("CustomerId is not valid.");

            var movies = _context.Movies.Where(m => newRentalDto.MovieIds.Contains(m.Id)).ToList();

            if (movies.Count != newRentalDto.MovieIds.Count)
                return BadRequest("One or more MovieIds are valid.");

            foreach (var movie in movies)
            {
                if (movie.NumberInStock == 0)
                    return BadRequest("Movie is not available.");

                movie.NumberInStock--;

                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };

                _context.Add(rental);
            }

            _context.SaveChanges();

            return Ok();
        }
    }
}