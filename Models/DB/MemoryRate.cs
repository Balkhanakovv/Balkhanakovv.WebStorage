using System.ComponentModel.DataAnnotations;

namespace Balkhanakovv.WebStorage.Models.DB
{
    public class MemoryRate
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Size { get; set; }

        public List<User> Users { get; set; }
    }
}
