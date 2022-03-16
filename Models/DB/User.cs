using System.ComponentModel.DataAnnotations;

namespace Balkhanakovv.WebStorage.Models.DB
{
    /// <summary>
    /// Модель пользователя
    /// </summary>
    public class User
    {
        /// <summary>
        /// Идентификатор пользователя (ключевое поле)
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Имя пользователя (для входа в систему)
        /// </summary>
        [Required]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Пароль пользователя
        /// </summary>
        public string? Password { get; set; }

        /// <summary>
        /// Отображаемое имя пользователя (например, ФИО)
        /// </summary>
        public string? FullName { get; set; }

        /// <summary>
        /// Индекс группы пользователя
        /// </summary>
        [Required]
        public int GroupId { get; set; }
        public Group? Group { get; set; }

        /// <summary>
        /// Индекс максимального объема используемой памяти
        /// </summary>
        [Required]
        public int RateId { get; set; }
        public MemoryRate? Rate { get; set; }

        public List<Document>? Documents { get; set; }
    }
}
