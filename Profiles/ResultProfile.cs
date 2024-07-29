using AnotherQuizAPI.DTOs.ResultDTOs;
using AnotherQuizAPI.Model;
using AutoMapper;

namespace AnotherQuizAPI.Profiles
{
    public class ResultProfile : Profile
    {
        public ResultProfile()
        {
            CreateMap<Result, ResultReadDTO>().ReverseMap();
            CreateMap<ResultCreateDTO, Result>()
                .ForMember(dest => dest.User, opt => opt.Ignore())
                .ForMember(dest => dest.QuizLists, opt => opt.Ignore());
            CreateMap<ResultUpdateDTO, Result>()
                .ForMember(dest => dest.User, opt => opt.Ignore())
                .ForMember(dest => dest.QuizLists, opt => opt.Ignore());

        }
    }
}