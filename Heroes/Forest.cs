using MonsterModels;
using UserRegistration;

namespace Heroes
{
    public class Forest
    {
        public static int Start(User user, Hero hero)
        {
            Console.WriteLine("You have entered the forest!");
            Console.WriteLine("In the forest you have 3 options:");
            Console.WriteLine("1. Fight a goblin");
            Console.WriteLine("2. Fight a troll");
            Console.WriteLine("3. Fight a dragon");
            do
            {
                var input = int.TryParse(Console.ReadLine(), out var iresult) ? iresult : 0;
                var attack = new Attack();
                switch (input)
                {
                    case 1:
                        var goblin = MonsterCreation.goblin;
                        attack.AttackMonster(goblin, user, hero);
                        break;
                    case 2:
                        var troll = MonsterCreation.troll;
                        attack.AttackMonster(troll, user, hero);
                        break;
                    case 3:
                        var dragon = MonsterCreation.dragon;
                        attack.AttackMonster(dragon, user, hero);
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