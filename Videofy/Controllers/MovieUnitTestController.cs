using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Videofy.Models;

namespace Videofy.Controllers
{
    public class MovieUnitTestController : Controller
    {
        [NonAction]
        public List<Movie> GetMoviesList()
        {
            return new List<Movie>
            {
                new Movie
                {
                    Id = 1,
                    Title = "My Life",
                    ReleaseDate = DateTime.Parse("1991-1-18"),
                    Genre = "Comedy",
                    Price = 7.99M
                },

                new Movie
                {
                    Id = 2,
                    Title = "The Shawshank Redemption",
                    ReleaseDate = DateTime.Parse("1994-3-13"),
                    Genre = "Drama",
                    Price = 8.99M
                },

                new Movie
                {
                    Id = 3,
                    Title = "The GodFather",
                    ReleaseDate = DateTime.Parse("1991-4-16"),
                    Genre = "Crime",
                    Price = 9.99M
                },
            };
        }
        public IActionResult Index()
        {
            var movies = from s in GetMoviesList() select s;
            return View(movies);
        }

        public IActionResult Movie()
        {
            var movies = from e in GetMoviesList() orderby e.Id select e;
            return View(movies);
        }
    }
}