using AutoMapper;
using CityGuide.Entities;
using CityGuide.Models;

namespace CityGuide.Profiles
{
    public class PointOfInterestProfile :  Profile
    {
        public PointOfInterestProfile()
        {
            CreateMap<PointOfInterest, PointOfInterestDto>();
            CreateMap<PointOfInterestCreationDto, PointOfInterest>();
            CreateMap<PointOfInterestUpdateDto, PointOfInterest>();
            //CreateMap<Entities.PointOfInterest, Models.PointOfInterestForUpdateDto>();
        }
    }
}
