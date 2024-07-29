using System.ComponentModel.DataAnnotations;

namespace AnotherQuizAPI.Model
{
    public class Result
    {
        [Key]
        public int Id { get; set; }
        public int Score { get; set; }

        public int UserId { get; set; }
        public virtual User? User { get; set; }

        public int QuizListId { get; set; }
        public virtual QuizList? QuizLists { get; set; }
    }
}