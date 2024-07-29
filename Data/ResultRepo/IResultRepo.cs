using AnotherQuizAPI.Model;

namespace AnotherQuizAPI.Data.ResultRepo
{
    public interface IResultRepo
    {
        Task<ICollection<Result>> GetAllResultByUserId(int userId);
        Task<Result?> GetResultByIdAndUserId(int id, int userId);
        Task<ICollection<Result>> GetAllResult();
        Task<Result?> GetResultById(int id);
        Task AddResult(Result result);
        void UpdateResult(Result result);
        void DeleteResult(Result result);

        Task<bool> SaveChanges();


    }
}