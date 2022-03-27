namespace Balkhanakovv.WebStorage.Services.StorageService
{
    public class StorageService : IStorageService
    {
        /// <summary>
        /// Строка директории хранения файлов
        /// </summary>
        public string StoragePathString { get; set; } = "C:/Files";
    }
}
