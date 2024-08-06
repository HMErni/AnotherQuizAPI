using AnotherQuizAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace AnotherQuizAPI.Data.UserRepo
{
    public class UserRepo : IUserRepo
    {
        private readonly QuizDBContext _context;

        public UserRepo(QuizDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _context.Users.Include(x => x.Results).ToListAsync();
        }

        public async Task<User?> GetUserById(int id)
        {
            return await _context.Users.Include(x => x.Results).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<User?> GetUserByUsernameAndPassword(string username, string password)
        {
            return await _context.Users.Include(
                x => x.Results).FirstOrDefaultAsync(
                    x => EF.Functions.Collate(
                        x.Username, "Latin1_General_BIN") == username &&
                        EF.Functions.Collate(
                            x.Password, "Latin1_General_BIN") == password);
        }

        public async Task<User?> getUsername(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(
                x => EF.Functions.Collate(x.Username, "Latin1_General_BIN") == username);
        }

        public async Task AddUser(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            await _context.Users.AddAsync(user);
        }

        public void DeleteUser(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            _context.Users.Remove(user);
        }

        public void UpdateUser(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            _context.Users.Update(user);
        }

        public async Task<bool> SaveChanges()
        {
            return await _context.SaveChangesAsync() >= 0;
        }
    }
}