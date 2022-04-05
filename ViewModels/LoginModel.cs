using System.ComponentModel.DataAnnotations;

namespace Balkhanakovv.WebStorage.ViewModels
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Не указано имя пользователя")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
    }
}
