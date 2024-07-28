using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace AnotherQuizAPI.Model
{
    [Index(nameof(Username), IsUnique = true)]
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Username { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
        [Required]
        public string Role { get; set; } = string.Empty;

        public virtual ICollection<Result> Results { get; set; } = new List<Result>();
    }
}