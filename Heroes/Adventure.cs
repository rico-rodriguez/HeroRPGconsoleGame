using UserRegistration;

namespace Heroes
{
    public class Adventure
    {
        public static int AdventureStart(User user, Hero hero)
        {
            Console.WriteLine("You have 5 options:");
            Console.WriteLine("1. Fight in the forest");
            Console.WriteLine("2. Loot the mountains");
            Console.WriteLine("3. Fish in the sea");
            Console.WriteLine("4. Train");
            Console.WriteLine("5. Check your stats");
            do
            {
                var input = int.TryParse(Console.ReadLine(), out var iresult) ? iresult : 0;
                switch (input)
                {
                    case 1:
                        Forest.Start(user, hero);
                        break;
                    case 2:
                        Mountain.Start(user, hero);
                        break;
                    case 3:
                        Sea.SeaStart();
                        break;
                    case 4:
                        Training.TrainingStart();
                        break;
                    case 5:
                        Stats.StatsStart(hero, user);
                        break;
                    default:
                        Console.WriteLine("You have not selected a valid option. Please try again.");
                        continue;
                }
                return input;
            } while (true);
        }
    }
}