using Application.Commands;
using Application.Responses;
using AutoMapper;
using Core.Entities;

namespace Application.Mappers
{
    public class MovieMappingProfile : Profile
    {
        public MovieMappingProfile()
        {
            CreateMap<Movie, MovieResponse>().ReverseMap();
            CreateMap<Movie, CreateMovieCommand>().ReverseMap();
        }
    }
}