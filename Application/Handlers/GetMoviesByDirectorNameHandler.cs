using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Mappers;
using Application.Queries;
using Application.Responses;
using Core.Repositories;
using MediatR;

namespace Application.Handlers
{
    public class
        GetMoviesByDirectorNameHandler : IRequestHandler<GetMoviesByDirectorNameQuery, IEnumerable<MovieResponse>>
    {
        private readonly IMovieRepository _movieRepository;

        public GetMoviesByDirectorNameHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<IEnumerable<MovieResponse>> Handle(GetMoviesByDirectorNameQuery request,
            CancellationToken cancellationToken)
        {
            var movieList = await _movieRepository.GetMoviesByDirectorName(request.DirectorName);
            var movieResponseList = MovieMapper.Mapper.Map<IEnumerable<MovieResponse>>(movieList);
            return movieResponseList;
        }
    }
}