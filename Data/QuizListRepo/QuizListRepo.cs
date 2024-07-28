using AnotherQuizAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace AnotherQuizAPI.Data.QuizListRepo
{
    public class QuizListRepo : IQuizListRepo
    {
        private readonly QuizDBContext _context;

        public QuizListRepo(QuizDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<QuizList>> GetAllQuizLists()
        {
            return await _context.QuizLists.Include(x => x.QuizItems).ToListAsync();
        }

        public async Task<QuizList?> GetQuizListById(int id)
        {
            return await _context.QuizLists.Include(x => x.QuizItems).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddQuizList(QuizList quizList)
        {
            if (quizList == null)
                throw new ArgumentNullException(nameof(quizList));

            await _context.QuizLists.AddAsync(quizList);
        }

        void IQuizListRepo.DeleteQuizList(QuizList quizList)
        {
            if (quizList == null)
                throw new ArgumentNullException(nameof(quizList));

            _context.QuizLists.Remove(quizList);
        }

        void IQuizListRepo.UpdateQuizList(QuizList quizList)
        {
            if (quizList == null)
                throw new ArgumentNullException(nameof(quizList));

            _context.QuizLists.Update(quizList);
        }

        public async Task<bool> SaveChanges()
        {
            return await _context.SaveChangesAsync() >= 0;
        }
    }
}