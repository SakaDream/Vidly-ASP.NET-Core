using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vidly.Data;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        public IActionResult Index()
        {
            if(User.IsInRole("Admin") || User.IsInRole("MovieManager"))
                return View("List");
            return View("ReadOnlyList");
        }

        [Authorize(Roles = "Admin, MovieManager")]
        public IActionResult New()
        {
            var viewModel = new MovieFormViewModel
            {
                Movie = new Movie
                {
                    ReleaseDate = DateTime.MinValue,
                    NumberInStock = 0
                },
                Genres = _context.Genres.ToList()
            };
            return View("MovieForm", viewModel);
        }

        [Authorize(Roles = "Admin, MovieManager")]
        public IActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return NotFound();
            var viewModel = new MovieFormViewModel
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };
            return View("MovieForm", viewModel);
        }

        [HttpPost]
        [Authorize(Roles = "Admin, MovieManager")]
        [ValidateAntiForgeryToken]
        public IActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };

            ViewData["Movie"] = movie; // Do not use!
            ViewBag.Movie = movie; // Do not use!

            var customers = new List<Customer>
            {
                new Customer {Name = "Customer 1"},
                new Customer {Name = "Customer 2"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }

        public IActionResult Details(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            return View(movie);
        }

        [Route("movies/released/{year:regex(\\d{{4}}):range(2008, 2017)}/{month:regex(\\d{{2}}):range(1, 12)}")]
        public IActionResult ByReleaseDate(int year, int month)
        {
            return Content($"Movies By Release {month}/{year}");
        }
    }
}