using AnotherQuizAPI.DTOs.QuizItemDTOs;
using AnotherQuizAPI.Model;

namespace AnotherQuizAPI.DTOs.QuizListDTOs
{
    public class QuizListReadDTO
    {
        public int Id { get; set; }
        public string QuizName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public ICollection<QuizItemReadDTO> QuizItems { get; set; } = new List<QuizItemReadDTO>();
    }
}