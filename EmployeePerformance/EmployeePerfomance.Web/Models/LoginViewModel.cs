using System.ComponentModel.DataAnnotations;

namespace EmployeePerfomance.Web.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Enter Login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Enter Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
