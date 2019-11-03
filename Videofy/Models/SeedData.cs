 paolo_v4_login_logout
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Videofy.Data;

namespace Videofy.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new VideofyContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<VideofyContext>>()))
            {
                /// Look for any movies.
                /// If there are any movies in the DB, 
                /// the seed initializer returns and no movies are added.
                if (context.Videos.Any())
                {
                    return;   // DB has been seeded
                }

                context.Videos.AddRange(
                    new Video
                    {
                        Title = "When Harry Met Sally",
                        ReleaseDate = DateTime.Parse("1989-2-12"),
                        Genre = "Romantic Comedy",
                        Type = "Movie",
                        Price = 7.99M
                    },

                    new Video
                    {
                        Title = "Ghostbusters ",
                        ReleaseDate = DateTime.Parse("1984-3-13"),
                        Genre = "Comedy",
                        Type = "Movie",
                        Price = 8.99M
                    },

                    new Video
                    {
                        Title = "Ghostbusters 2",
                        ReleaseDate = DateTime.Parse("1986-2-23"),
                        Genre = "Comedy",
                        Type = "Movie",
                        Price = 9.99M
                    },

                    new Video
                    {
                        Title = "Rio Bravo",
                        ReleaseDate = DateTime.Parse("1959-4-15"),
                        Genre = "Western",
                        Type = "Movie",
                        Price = 3.99M
                    }
                );
                context.SaveChanges();
            }
        }
    }
}

﻿using Microsoft.EntityFrameworkCore;
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
 master
