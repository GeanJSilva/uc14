using System.ComponentModel.DataAnnotations;

namespace ExoApi_turma15.ViewModel
{
    public class LoginViewModel
    {

        [Required(ErrorMessage ="informe o Email")]
        public String email {  get; set; }

        [Required(ErrorMessage ="Informe a Senha")]
        public String senha { get; set; }
       
    }
}
