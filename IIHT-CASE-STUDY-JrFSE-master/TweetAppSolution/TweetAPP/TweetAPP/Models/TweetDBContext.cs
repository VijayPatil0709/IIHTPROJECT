namespace TweetAPP.Models
{
    using Microsoft.EntityFrameworkCore;

    public class TweetDBContext : DbContext
    {
        
        public TweetDBContext()
        {
        }

       
        public TweetDBContext(DbContextOptions<TweetDBContext> options)
            : base(options)
        {
        }

       
        public DbSet<User> User { get; set; }
     
        public DbSet<Tweet> Tweets { get; set; }
 
        public DbSet<Comment> Comments { get; set; }
   
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           optionsBuilder.UseSqlServer("Server=VIJAY-LAPTOP;Database=Tweet_APP;Trusted_Connection=True;");
        }
    }
}
