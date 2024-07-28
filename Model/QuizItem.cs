using System.ComponentModel.DataAnnotations;

namespace AnotherQuizAPI.Model
{
    public class QuizItem
    {
        [Key]
        public int Id { get; set; }
        public string Question { get; set; } = string.Empty;
        public string CorrectAnswer { get; set; } = string.Empty;
        public List<string> Answers { get; set; } = new List<string>();

        public int QuizListId { get; set; }
        public virtual QuizList? QuizList { get; set; }

    }
}