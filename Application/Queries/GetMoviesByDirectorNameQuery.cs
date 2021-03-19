using System.Collections.Generic;
using Application.Responses;
using MediatR;

namespace Application.Queries
{
    public class GetMoviesByDirectorNameQuery : IRequest<IEnumerable<MovieResponse>>
    {
        public GetMoviesByDirectorNameQuery(string directorName)
        {
            DirectorName = directorName;
        }

        public string DirectorName { get; set; }
    }
}