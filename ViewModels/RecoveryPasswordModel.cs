using System.ComponentModel.DataAnnotations;

namespace Balkhanakovv.WebStorage.ViewModels
{
    public class RecoveryPasswordModel
    {
        [Required(ErrorMessage = "Введите свой логин")]
        public string Name { get; set; } = null!;
    }
}
