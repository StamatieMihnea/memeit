using System.ComponentModel.DataAnnotations;
using MemeIT.Entities;

namespace MemeIT.Models
{
    public class UserModel
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "A valid email address must be set")]
        [RegularExpression(@"^.*@stud\.acs\.upb\.ro$", ErrorMessage = "University email must be used (@stud.acs.upb.ro)")]
        public string Email
        {
            get;
            set;
        }

        [Required(ErrorMessage = "Username is required")]
        [MaxLength(User.MaxUsernameLimit, ErrorMessage = "Username must be between 8 and 32 characters")]
        [MinLength(User.MinUsernameLimit, ErrorMessage = "Username must be between 8 and 32 characters")]
        public string Username
        {
            get;
            set;
        }

        [Required(ErrorMessage = "Password is required")]
        [MaxLength(User.MaxPasswordLimit, ErrorMessage = "Password must be between 8 and 32 characters")]
        [MinLength(User.MinPasswordLimit, ErrorMessage = "Password must be between 8 and 32 characters")]
        public string Password
        {
            get;
            set;
        }
    }
}
