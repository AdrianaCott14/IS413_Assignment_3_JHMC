using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movies.Models
{
    public class EFMoviesRepository : IMoviesRepository
    {

        private MoviesDBContext _context;

        //constructor
        public EFMoviesRepository(MoviesDBContext ctx)
        {
            _context = ctx;
        }
        public IQueryable<AppResponse> Movies => _context.Movies;
    }
}