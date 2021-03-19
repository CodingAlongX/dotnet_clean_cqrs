using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Commands;
using Application.Mappers;
using Application.Responses;
using Core.Entities;
using Core.Repositories;
using MediatR;

namespace Application.Handlers
{
    public class CreateMovieHandler : IRequestHandler<CreateMovieCommand, MovieResponse>
    {
        private readonly IMovieRepository _movieRepository;

        public CreateMovieHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<MovieResponse> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
        {
            var movieEntity = MovieMapper.Mapper.Map<Movie>(request);

            if (movieEntity is null)
            {
                throw new ApplicationException("There is an issue with mapping");
            }

            var newMovie = await _movieRepository.AddAsync(movieEntity);
            var movieResponse = MovieMapper.Mapper.Map<MovieResponse>(newMovie);

            return movieResponse;
        }
    }

    public class ApplicationException : Exception
    {
        public ApplicationException(string message) : base(message)
        {
        }
    }
}