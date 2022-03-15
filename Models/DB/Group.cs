using System.ComponentModel.DataAnnotations;

namespace Balkhanakovv.WebStorage.Models.DB
{
    /// <summary>
    /// Модель группы пользователей
    /// </summary>
    public class Group
    {
        /// <summary>
        /// Идентификатор группы пользователей
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Имя группы пользователей
        /// </summary>
        [Required]
        public string Name { get; set; }

        public List<User> Users { get; set; }
    }
}
