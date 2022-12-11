using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MemeIT.Entities
{
    public class Meme
    {
        public const int MaxDescriptionLimit = 2500;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MemeId
        {
            get;
            set;
        }

        [Required(ErrorMessage = "Meme description is required")]
        [MaxLength(MaxDescriptionLimit, ErrorMessage = "Meme description must be less than 2500 characters long")]
        public string Description
        {
            get;
            set;
        }
    }
}
