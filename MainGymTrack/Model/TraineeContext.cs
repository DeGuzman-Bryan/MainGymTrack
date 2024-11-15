using Microsoft.EntityFrameworkCore;

namespace MainGymTrack.Model
{
    public class TraineeContext : DbContext
    {
        public TraineeContext(DbContextOptions<TraineeContext> options) : base(options)
        {
           

        }
       public DbSet<Model1> model1 {  get; set; } 
    }
}

            
        
    