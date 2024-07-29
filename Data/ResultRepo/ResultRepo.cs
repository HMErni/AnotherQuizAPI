using System.Security.Cryptography;
using AnotherQuizAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace AnotherQuizAPI.Data.ResultRepo
{
    public class ResultRepo : IResultRepo
    {
        private readonly QuizDBContext _context;

        public ResultRepo(QuizDBContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Result>> GetAllResult()
        {
            return await _context.Results.ToListAsync();
        }

        public async Task<ICollection<Result>> GetAllResultByUserId(int userId)
        {
            return await _context.Results.Where(x => x.UserId == userId).ToListAsync();
        }

        public async Task<Result?> GetResultById(int id)
        {
            return await _context.Results.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Result?> GetResultByIdAndUserId(int id, int userId)
        {
            return await _context.Results.Where(x => x.UserId == userId).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddResult(Result result)
        {
            if (result == null)
                throw new ArgumentNullException(nameof(result));

            await _context.Results.AddAsync(result);
        }

        public void UpdateResult(Result result)
        {
            if (result == null)
                throw new ArgumentNullException(nameof(result));

            _context.Results.Update(result);

        }

        public void DeleteResult(Result result)
        {
            if (result == null)
                throw new ArgumentNullException(nameof(result));

            _context.Results.Remove(result);

        }

        public async Task<bool> SaveChanges()
        {
            return await _context.SaveChangesAsync() >= 0;
        }


    }
}