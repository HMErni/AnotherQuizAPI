namespace AnotherQuizAPI.DTOs.QuizItemDTOs
{
    public class QuizItemUpdateDTO
    {
        public string Question { get; set; } = string.Empty;
        public string CorrectAnswer { get; set; } = string.Empty;
        public List<string> Answers { get; set; } = new List<string>();
    }
}