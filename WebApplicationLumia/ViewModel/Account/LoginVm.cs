using System.ComponentModel.DataAnnotations;

namespace WebApplicationLumia.ViewModel.Account
{
    public class LoginVm
    {


        [Required]
        public string UserNameOrEmail { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
