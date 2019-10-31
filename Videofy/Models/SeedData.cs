using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Videofy.Data;
using System;
using System.Linq;

namespace Videofy.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new MvcMovieContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcMovieContext>>());
            if (context.Movie.Any())
            {
                return;
            }

            context.Movie.AddRange(
                new Movie
                {
                    Title = "My Life",
                    ReleaseDate = DateTime.Parse("1991-1-18"),
                    Genre = "Comedy",
                    Price = 7.99M
                },

                new Movie
                {
                    Title = "The Shawshank Redemption",
                    ReleaseDate = DateTime.Parse("1994-3-13"),
                    Genre = "Drama",
                    Price = 8.99M
                },

                new Movie
                {
                    Title = "The GodFather",
                    ReleaseDate = DateTime.Parse("1991-4-16"),
                    Genre = "Crime",
                    Price = 9.99M
                },

                new Movie
                {
                    Title = "The Dark Knight",
                    ReleaseDate = DateTime.Parse("2008-4-15"),
                    Genre = "Action",
                    Price = 3.99M
                },

                new Movie
                {
                    Title = "Fight Club",
                    ReleaseDate = DateTime.Parse("1999-4-06"),
                    Genre = "Drama",
                    Price = 6.99M
                }
            );
            context.SaveChanges();
        }
    }
}