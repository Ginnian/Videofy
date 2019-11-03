using System;
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
