using System.ComponentModel.DataAnnotations;

namespace Balkhanakovv.WebStorage.Models.DB
{
    /// <summary>
    /// Модель типа документа
    /// </summary>
    public class DocumentType
    {
        /// <summary>
        /// Идентификатор типа документа
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Название типа документа
        /// </summary>
        [Required]
        public string Name { get; set; }

        public List<Document> Documents { get; set; }
    }
}
