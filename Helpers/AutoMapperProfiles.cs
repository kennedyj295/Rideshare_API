using AutoMapper;
using Rideshare_API.DTOs;
using Rideshare_API.Entities;

namespace Rideshare_API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles() 
        {
            CreateMap<RegisterDTO, Rider>();
            CreateMap<RegisterDTO, Driver>();
            CreateMap<Rider, RiderDTO>();
            CreateMap<Driver, DriverDTO>();
        }
    }
}
