using AnotherQuizAPI.DTOs.QuizItemDTOs;

namespace AnotherQuizAPI.DTOs.QuizListDTOs
{
    public class QuizListCreateDTO
    {
        public string QuizName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public virtual ICollection<QuizItemUpdateDTO> QuizItems { get; set; } = new List<QuizItemUpdateDTO>();
    }
}