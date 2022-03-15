using System.ComponentModel.DataAnnotations;

namespace Balkhanakovv.WebStorage.Models.DB
{
    /// <summary>
    /// Модель максимального объема используемой памяти
    /// </summary>
    public class MemoryRate
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Максимальный размер
        /// </summary>
        [Required]
        public int Size { get; set; }

        public List<User> Users { get; set; }
    }
}
