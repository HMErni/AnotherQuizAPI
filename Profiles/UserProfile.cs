using AnotherQuizAPI.DTOs.UserDTOs;
using AnotherQuizAPI.Model;
using AutoMapper;

namespace AnotherQuizAPI.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserReadDTO>()
                .ReverseMap();
            CreateMap<UserCreateDTO, User>();
            CreateMap<UserUpdateDTO, User>();
            CreateMap<User, UsernameReadDTO>().ReverseMap();
        }
    }
}