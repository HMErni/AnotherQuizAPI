using AnotherQuizAPI.Model;

namespace AnotherQuizAPI.Data.UserRepo
{
    public interface IUserRepo
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<User?> GetUserById(int id);
        Task<User?> GetUserByUsernameAndPassword(string username, string password);
        Task AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(User user);
        Task<bool> SaveChanges();
    }
}