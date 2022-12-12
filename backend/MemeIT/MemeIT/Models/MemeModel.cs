using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MemeIT.Entities;

namespace MemeIT.Models
{
    public class MemeModel
    {
        public int MemeId { get; set; }

        [Required(ErrorMessage = "Meme description is required")]
        [MaxLength(Meme.MaxDescriptionLimit, ErrorMessage = "Meme description must be less than 2500 characters long")]
        public string Description { get; set; }
    }
}