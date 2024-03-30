using AutoMapper;
using platformservice.Dtos;
using platformservice.Models;

namespace platformservice.Profiles
{
    public class PlatformProfile : Profile
    {
        public PlatformProfile()
        {
            // source-->target
            CreateMap<Platform, PlatformReadDto>();
            CreateMap<CreatePlatformDto, Platform>();
        }
    }
}