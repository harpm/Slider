using System.ComponentModel.DataAnnotations;

namespace Slider5.Models
{
    public class Song
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(90)]
        [MinLength(3)]
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
