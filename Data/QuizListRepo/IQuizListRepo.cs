using AnotherQuizAPI.Model;

namespace AnotherQuizAPI.Data.QuizListRepo
{
    public interface IQuizListRepo
    {
        Task<IEnumerable<QuizList>> GetAllQuizLists();
        Task<QuizList?> GetQuizListById(int id);
        Task AddQuizList(QuizList quizList);
        void DeleteQuizList(QuizList quizList);
        void UpdateQuizList(QuizList quizList);
        Task<bool> SaveChanges();
    }
}