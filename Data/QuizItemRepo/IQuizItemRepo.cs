

using AnotherQuizAPI.Model;

namespace AnotherQuizAPI.Data.QuizIemRepo
{
    public interface IQuizItemRepo
    {
        Task<IEnumerable<QuizItem>> GetAllQuizItems();
        Task<IEnumerable<QuizItem>> GetAllQuizItemsByQuizList(int quizListId);
        Task<QuizItem?> GetQuizItemById(int id);
        Task AddQuizItem(QuizItem quizItem);
        void UpdateQuizItem(QuizItem quizItem);
        void DeleteQuizItem(QuizItem quizItem);
        Task<bool> SaveChanges();

    }
}