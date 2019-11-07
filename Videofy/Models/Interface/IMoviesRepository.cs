using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Videofy.Models.Interface
{
    public interface IMoviesRepository
    {
        //IQueryable<Movie> Movies { get; set; }
        IEnumerable<Movie> Movies { get; set; }

        //Movie GetMovieById(int MovieId);
    }
}
