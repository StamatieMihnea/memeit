using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MemeIT.Models
{
    public class Meme
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MemeId
        {
            get;
            set;
        }

        [Required]
        public string Description
        {
            get;
            set;
        }
    }
}
