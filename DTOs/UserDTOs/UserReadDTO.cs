using AnotherQuizAPI.DTOs.ResultDTOs;

namespace AnotherQuizAPI.DTOs.UserDTOs
{
    public class UserReadDTO
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public virtual ICollection<ResultReadDTO> Results { get; set; } = new List<ResultReadDTO>();
    }
}