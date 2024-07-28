using AnotherQuizAPI.DTOs.QuizItemDTOs;
using AnotherQuizAPI.Model;
using AutoMapper;

namespace AnotherQuizAPI.Profiles
{
    public class QuizItemProfile : Profile
    {
        public QuizItemProfile()
        {
            CreateMap<QuizItem, QuizItemReadDTO>()
                .ReverseMap();
            CreateMap<QuizItemCreateDTO, QuizItem>()
                .ForMember(dest => dest.QuizList, opt => opt.Ignore());
            CreateMap<QuizItemUpdateDTO, QuizItem>()
                .ForMember(dest => dest.QuizList, opt => opt.Ignore());
        }
    }
}