using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MemeIT.Entities
{
    public class Meme
    {
        public const int MaxDescriptionLimit = 2500;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MemeId { get; set; }

        [Required]
        [MaxLength(MaxDescriptionLimit)]
        public string Description { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }
    }
}