using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Repositories;
using Infrastructure.Data;
using Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        public MovieRepository(MovieContext movieContext) : base(movieContext)
        {
        }

        public async Task<IEnumerable<Movie>> GetMoviesByDirectorName(string directorName)
        {
            return await MovieContext.Movies.Where(m => m.DirectorName == directorName).ToListAsync();
        }
    }
}