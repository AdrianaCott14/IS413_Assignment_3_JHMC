using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace movies.Models
{
    public class MoviesDBContext : DbContext
    {
        //set up the constructor for DBContext Model
        public MoviesDBContext (DbContextOptions<MoviesDBContext> options) : base (options)
        {

        }

        public DbSet<AppResponse> Movies { get; set; }
    }
}
