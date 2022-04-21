using System.ComponentModel.DataAnnotations;

namespace Balkhanakovv.WebStorage.ViewModels
{
    public class ChangePasswordModel
    {
        [Required(ErrorMessage = "Не указан старый пароль")]
        public string OldPassword { get; set; } = null!;

        [Required(ErrorMessage = "Не указан новый пароль")]
        public string NewPassword { get; set; } = null!;

        [Required(ErrorMessage = "Не указан пароль проверки")]
        public string RepeatPassword { get; set; } = null!;
    }
}
