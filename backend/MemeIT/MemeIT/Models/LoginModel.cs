using MemeIT.Entities;
using System.ComponentModel.DataAnnotations;

namespace MemeIT.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Username is required")]
        public string Username
        {
            get;
            set;
        }

        [Required(ErrorMessage = "Password is required")]
        public string Password
        {
            get;
            set;
        }
    }
}
