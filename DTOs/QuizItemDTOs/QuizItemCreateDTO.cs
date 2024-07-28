namespace AnotherQuizAPI.DTOs.QuizItemDTOs
{
    public class QuizItemCreateDTO
    {
        public string Question { get; set; } = string.Empty;
        public string CorrectAnswer { get; set; } = string.Empty;
        public List<string> Answers { get; set; } = new List<string>();

        public int QuizListId { get; set; }
    }
}