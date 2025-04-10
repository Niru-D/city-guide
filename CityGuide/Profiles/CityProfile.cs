using AutoMapper;
using CityGuide.Entities;
using CityGuide.Models;

namespace CityGuide.Profiles
{
    public class CityProfile : Profile
    {
        public CityProfile()
        {
            CreateMap<City, CityWithoutPointsOfInterestDto>();
            CreateMap<City, CityDto>();
        }
    }
}
