using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using UserRegistration;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace HeroesDB
{
    public class HeroesDBContext : DbContext
    {

        public DbSet<User> User { get; set; }
        public DbSet<Hero> Hero { get; set; }


        public HeroesDBContext()
        {

        }

        public HeroesDBContext(DbContextOptions options)
            : base(options)
        {

        }

        //add to allow migrations when the context is not built
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var builder = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

                var config = builder.Build();
                var cnstr = config["ConnectionStrings:HeroesDB"];
                var options = new DbContextOptionsBuilder<HeroesDBContext>().UseSqlServer(cnstr);
                optionsBuilder.UseSqlServer(cnstr);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(Entity =>
            {
                Entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });
        }
    }
}