using HeroModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HeroesDB
{
    public class HeroesDBContext : DbContext
    {
        public static DbSet<HeroModels.Mage> Mages { get; set; }
        public static DbSet<HeroModels.Archer> Archers { get; set; }
        public static DbSet<HeroModels.Weapon> Weapons { get; set; }
        public static DbSet<HeroModels.Food> Foods { get; set; }
        public DbSet<UserRegistration.UserController> UserControllers { get; set; }
        public DbSet<HeroCreation> HeroCreations { get; set; }
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
    }
}
