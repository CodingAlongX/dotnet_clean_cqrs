using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Repositories
{
    public interface IMovieRepository : IRepository<Movie>
    {
        Task<IEnumerable<Movie>> GetMoviesByDirectorName(string directorName);
    }
}