using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MemeIT.Entities
{
    public class User
    {
        public User()
        {
            Memes = new List<Meme>();
        }

        public const int MaxPasswordLimit = 32;
        public const int MinPasswordLimit = 8;
        public const int MaxUsernameLimit = 32;
        public const int MinUsernameLimit = 8;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Required] public string Email { get; set; }

        [Required]
        [MaxLength(MaxUsernameLimit)]
        [MinLength(MinUsernameLimit)]
        public string Username { get; set; }

        [Required] public string Password { get; set; }

        public List<Meme> Memes { get; set; }
    }
}