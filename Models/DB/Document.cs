using System.ComponentModel.DataAnnotations;

namespace Balkhanakovv.WebStorage.Models.DB
{
    /// <summary>
    /// Модель документа
    /// </summary>
    public class Document
    {
        /// <summary>
        /// Идентификатор документа
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Имя документа
        /// </summary>
        [Required]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Идентификатор пользователя (владельца документа)
        /// </summary>
        [Required]
        public int UserId { get; set; }
        public User User { get; set; } = null!;

        /// <summary>
        /// Идентификатор типа документа
        /// </summary>
        [Required]
        public int TypeId { get; set; }
        public DocumentType Type { get; set; } = null!;

        /// <summary>
        /// Размер документа
        /// </summary>
        [Required]
        public int Size { get; set; }
    }
}
