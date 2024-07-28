using System.ComponentModel.DataAnnotations;

namespace AnotherQuizAPI.Model
{
    public class Result
    {
        [Key]
        public int Id { get; set; }
        public int Score { get; set; }

        public User? User { get; set; }

        public virtual ICollection<QuizList> QuizLists { get; set; } = new List<QuizList>();
    }
}