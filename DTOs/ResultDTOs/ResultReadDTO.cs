using AnotherQuizAPI.DTOs.QuizListDTOs;
using AnotherQuizAPI.DTOs.UserDTOs;
using AnotherQuizAPI.Model;

namespace AnotherQuizAPI.DTOs.ResultDTOs
{
    public class ResultReadDTO
    {
        public int Id { get; set; }
        public int Score { get; set; }

        public int UserId { get; set; }

        public int QuizListId { get; set; }
    }

}