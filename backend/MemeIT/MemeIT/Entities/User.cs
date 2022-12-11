using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MemeIT.Entities
{
    public class User
    {
        public const int MaxPasswordLimit = 32;
        public const int MinPasswordLimit = 8;
        public const int MaxUsernameLimit = 32;
        public const int MinUsernameLimit = 8;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId
        {
            get;
            set;
        }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "A valid email address must be set")]
        [RegularExpression(@"^.*@stud\.acs\.upb\.ro$", ErrorMessage = "University email must be used (@stud.acs.upb.ro)")]
        public string Email
        {
            get;
            set;
        }

        [Required(ErrorMessage = "Username is required")]
        [MaxLength(MaxUsernameLimit, ErrorMessage = "Username must be between 8 and 32 characters")]
        [MinLength(MinUsernameLimit, ErrorMessage = "Username must be between 8 and 32 characters")]
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
