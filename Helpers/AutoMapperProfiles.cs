using AutoMapper;
using Rideshare_API.DTOs;
using Rideshare_API.Entities;

namespace Rideshare_API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles() 
        {
            CreateMap<Rider, RiderDTO>();
            CreateMap<Driver, DriverDTO>();
        }
    }
}
