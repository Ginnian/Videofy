﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Videofy.Models
{
    public interface IMovieRepository
    {
        IQueryable<Movie> Movies { get; }
    }
}
