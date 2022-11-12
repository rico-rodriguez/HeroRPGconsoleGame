using HeroesDB;
using Microsoft.EntityFrameworkCore;
using UserRegistration;

namespace Heroes
{
    public class SelectCharacter
    {
        public static Hero CurrentHero;
        public static User CurrentUser;

        private string _cnstr;
        private static DbContextOptionsBuilder _optionsBuilder;

        public SelectCharacter()
        {
            _cnstr = Program._configuration["ConnectionStrings:HeroesDB"];
            _optionsBuilder = new DbContextOptionsBuilder<HeroesDBContext>().UseSqlServer(_cnstr);
        }

        public void WelcomeScreen()
        {
            Console.WriteLine("Welcome to the game!");
            Console.WriteLine("Please Log in or Register");
            Console.WriteLine("1. Log in");
            Console.WriteLine("2. Register");
            Console.WriteLine("3. Exit");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    LogIn();
                    break;
                case "2":
                    Register();
                    break;
                case "3":
                    Environment.Exit(1);
                    break;
                default:
                    Console.WriteLine("Please enter a valid choice");
                    WelcomeScreen();
                    break;
            }
        }

        private void Register()
        {
            Console.WriteLine("Please enter a username");
            string username = Console.ReadLine();
            Console.WriteLine("Please enter a password");
            string password = Console.ReadLine();
            User user = new User();
            user.Username = username;
            user.Password = password;
            var hero = new Hero();
            using (var context = new HeroesDBContext(_optionsBuilder.Options))
            {
                {
                    hero.User = user;
                    context.Hero.Add(hero);
                    user.Heroes.Add(hero);
                    context.User.Add(user);
                    context.SaveChanges();
                }
                CurrentHero = context.Hero.FirstOrDefault(h => h.User.Username == username);
                CurrentUser = context.User.Where(u => u.Username == username && u.Password == password).FirstOrDefault();
                Console.WriteLine("User created");
                Adventure.AdventureStart(CurrentUser, CurrentHero);
            }
        }

        private void LogIn()
        {
            Console.WriteLine("Please enter your username");
            string username = Console.ReadLine();
            Console.WriteLine("Please enter your password");
            string password = Console.ReadLine();
            using var context = new HeroesDBContext(_optionsBuilder.Options);
            var usercompare = new HeroesDBContext().User.Where(u => u.Username == username && u.Password == password);

            if (!usercompare.Any())
            {
                Console.WriteLine("User not found");
                WelcomeScreen();
            }
            CurrentHero = context.Hero.FirstOrDefault(h => h.User.Username == username);
            CurrentUser = context.User.Where(u => u.Username == username && u.Password == password).FirstOrDefault();
            context.SaveChanges();
            Adventure.AdventureStart(CurrentUser, CurrentHero);

        }
    }
}
