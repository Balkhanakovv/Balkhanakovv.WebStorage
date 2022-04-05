using System.ComponentModel.DataAnnotations;

namespace Balkhanakovv.WebStorage.ViewModels
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Не указано имя пользователя для входа")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароль введен неверно")]
        public string ConfirmPassword { get; set; } = null!;

        [Required(ErrorMessage = "Не указано имя пользователя для отображения")]
        public string FullName { get; set; } = null!;

        [Required(ErrorMessage = "Не выбрана группа пользователя")]
        public int GroupId { get; set; }

        [Required(ErrorMessage = "Не выбран лимит")]
        public int RateId { get; set; }
    }
}
