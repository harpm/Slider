using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Slider5.Models.Config;

namespace Slider5.Models.View
{
    public class ViewSong
    {
        public string Name { get; set; }

        [Required]
        public IFormFile File { get; set; }
    }
}
