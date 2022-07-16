using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Slider5.Models.Config;

namespace Slider5.Models.Dto
{
    public class DtoSong
    {
        [Required]
        [MaxLength(90)]
        [MinLength(3)]
        public string Name { get; set; }

        [Required]
        [Extension(new []{"mp3", "m4a"})]
        public IFormFile File { get; set; }
    }
}
