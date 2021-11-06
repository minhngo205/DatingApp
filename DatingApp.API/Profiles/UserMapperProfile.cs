using AutoMapper;
using DatingApp.DatingApp.API.Database.Entities;
using DatingApp.DatingApp.API.DTOs;
using DatingApp.DatingApp.API.Extensions;

namespace DatingApp.DatingApp.API.Profiles
{
    public class UserMapperProfile : Profile
    {
        public UserMapperProfile(){
            CreateMap<User, Memberdto>()
                .ForMember(
                    dest => dest.Age,
                    opt => opt.MapFrom(src => src.DateofBirth.CalculateAge())
                );

            CreateMap<ProfileDTO,User>();
        }
    }
}