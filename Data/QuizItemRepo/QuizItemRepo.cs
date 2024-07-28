using AnotherQuizAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace AnotherQuizAPI.Data.QuizIemRepo
{
    public class QuizItemRepo : IQuizItemRepo
    {
        private readonly QuizDBContext _context;

        public QuizItemRepo(QuizDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<QuizItem>> GetAllQuizItems()
        {
            return await _context.QuizItems.ToListAsync();
        }

        public async Task<IEnumerable<QuizItem>> GetAllQuizItemsByQuizList(int quizListId)
        {
            return await _context.QuizItems.Where(x => x.QuizListId == quizListId).ToListAsync();
        }

        public async Task<QuizItem?> GetQuizItemById(int id)
        {
            return await _context.QuizItems.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddQuizItem(QuizItem quizItem)
        {
            if (quizItem == null)
                throw new ArgumentNullException(nameof(quizItem));

            await _context.QuizItems.AddAsync(quizItem);
        }

        public void DeleteQuizItem(QuizItem quizItem)
        {
            if (quizItem == null)
                throw new ArgumentNullException(nameof(quizItem));

            _context.QuizItems.Remove(quizItem);
        }

        public void UpdateQuizItem(QuizItem quizItem)
        {
            if (quizItem == null)
                throw new ArgumentNullException(nameof(quizItem));

            _context.QuizItems.Update(quizItem);
        }

        public async Task<bool> SaveChanges()
        {
            return await _context.SaveChangesAsync() >= 0;
        }

    }
}