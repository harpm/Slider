using Microsoft.EntityFrameworkCore;

namespace Slider5.Models.Context
{
    public class SliderContext : DbContext
    {
        public SliderContext(DbContextOptions<SliderContext> options) : base(options)
        {
                
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Song> Songs { get; set; }
    }
}
