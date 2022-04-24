using System.ComponentModel.DataAnnotations;

namespace Balkhanakovv.WebStorage.Models.DB
{
    public class ForgottenPassword
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }
        public User User { get; set; } = null!;

        public bool IsRestored { get; set; } = false;
    }
}
