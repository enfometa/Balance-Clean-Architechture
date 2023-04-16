using AutoMapper;
using Balance.Application.Dtos;
using Balance.Core.Entities;

namespace Balance.Api.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>();
        }
    }
}
