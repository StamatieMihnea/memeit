using MemeIT.Entities;
using System.ComponentModel.DataAnnotations;
using TanvirArjel.CustomValidation.AspNetCore.Attributes;

namespace MemeIT.Models
{
    public class ImageMemeModel
    {
        private const int MaxSize = 2 * 1024;

        [Required]
        [FileType(FileType.Png, ErrorMessage = "The file format must be PNG")]
        [FileMaxSize(MaxSize, ErrorMessage = "The maximum size is 2MB")]
        public IFormFile Image { get; set; }

        [Required(ErrorMessage = "Meme description is required")]
        [MaxLength(Meme.MaxDescriptionLimit, ErrorMessage = "Meme description must be less than 2500 characters long")]
        public string Description { get; set; }
    }
}