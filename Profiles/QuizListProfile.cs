using AnotherQuizAPI.DTOs.QuizListDTOs;
using AnotherQuizAPI.Model;
using AutoMapper;

namespace AnotherQuizAPI.Profiles
{
    public class QuizListProfile : Profile
    {
        public QuizListProfile()
        {
            CreateMap<QuizList, QuizListReadDTO>()
                .ReverseMap();
            CreateMap<QuizListCreateDTO, QuizList>();
            CreateMap<QuizListUpdateDTO, QuizList>();
        }
    }
}