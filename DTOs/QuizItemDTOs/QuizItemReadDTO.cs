using AnotherQuizAPI.Model;

namespace AnotherQuizAPI.DTOs.QuizItemDTOs
{
    public class QuizItemReadDTO
    {
        public int Id { get; set; }
        public string Question { get; set; } = string.Empty;
        public string CorrectAnswer { get; set; } = string.Empty;
        public List<string> Answers { get; set; } = new List<string>();

        public int QuizListId { get; set; }
    }
}