using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Videofy.Models.Interface;

namespace Videofy.Models.Mock
{
    public class MockMoviesRepository : IMoviesRepository
    {
        public IEnumerable<Movie> Movies
        {
            get
            {
                return new List<Movie>
                {
                    new Movie
                    {
                        Title = "Avengers: Endgame",
                        ReleaseDate = DateTime.Parse("2019-4-24"),
                        Genre = "Action/Adventure",
                        Price = 7.99M
                    },
                    new Movie
                    {
                        Title = "Terminator: Judgement Day",
                        ReleaseDate = DateTime.Parse("2019-4-24"),
                        Genre = "Action/Adventure",
                        Price = 7.99M
                    }
                };
            }

            set => throw new NotImplementedException();
            //set;
        }
    }
}
