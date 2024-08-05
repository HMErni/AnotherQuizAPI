using AnotherQuizAPI.DTOs.QuizItemDTOs;
using AnotherQuizAPI.Model;

namespace AnotherQuizAPI.DTOs.QuizListDTOs
{
    public class QuizListUpdateDTO
    {
        public string QuizName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public virtual ICollection<QuizItemUpdateDTO> QuizItems { get; set; } = new List<QuizItemUpdateDTO>();
    }
}