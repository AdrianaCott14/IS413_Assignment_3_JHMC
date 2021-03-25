using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movies.Models
{
    //sets up the repository
    public class IMoviesRepository
    {
        IQueryable<AppResponse> Movies { get; }
    }
}
