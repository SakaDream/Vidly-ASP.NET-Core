using System;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vidly.Data;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/Movies")]
    public class MoviesController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public MoviesController(IMapper mapper)
        {
            _mapper = mapper;
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public IActionResult GetMovies(string query = null)
        {
            var moviesInclueQuery = _context.Movies.Include(m => m.Genre);
            var movieQuery = moviesInclueQuery.Where(m => m.NumberInStock > 0);

            if (String.IsNullOrWhiteSpace(query))
                movieQuery = movieQuery.Where(m => m.Name.Contains(query));

            return Ok(movieQuery.ToList().Select(_mapper.Map<Movie, MovieDto>));
        }

        [HttpGet("{id}", Name = "GetMovie")]
        public IActionResult GetMovie(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return NotFound();

            return Ok(_mapper.Map<Movie, MovieDto>(movie));
        }

        [HttpPost]
        [Authorize(Roles = "Admin, MovieManager")]
        public IActionResult CreateMovie([FromBody] MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var movie = _mapper.Map<MovieDto, Movie>(movieDto);

            _context.Movies.Add(movie);
            _context.SaveChanges();

            return CreatedAtRoute("GetMovie", new {id = movie.Id}, _mapper.Map<Movie, MovieDto>(movie));
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin, MovieManager")]
        public IActionResult UpdateMovie(int id, [FromBody] MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieInDb == null)
                return NotFound();

            _mapper.Map<MovieDto, Movie>(movieDto, movieInDb);

            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin, MovieManager")]
        public IActionResult DeleteMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return NotFound();

            _context.Movies.Remove(movie);
            _context.SaveChanges();

            return NoContent();
        }
    }
}