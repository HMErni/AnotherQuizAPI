using System.ComponentModel.DataAnnotations;

namespace AnotherQuizAPI.Model
{
    public class QuizList
    {
        [Key]
        public int Id { get; set; }
        public string QuizName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public virtual ICollection<QuizItem> QuizItems { get; set; } = new List<QuizItem>();

        public virtual ICollection<Result> Results { get; set; } = new List<Result>();
    }
}