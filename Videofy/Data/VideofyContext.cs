using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Videofy.Models;

namespace Videofy.Data
{
    public class VideofyContext : DbContext
    {
        public VideofyContext(DbContextOptions<VideofyContext> options)
            : base(options)
        {
        }

        public DbSet<Video> Videos { get; set; }

    }
}
