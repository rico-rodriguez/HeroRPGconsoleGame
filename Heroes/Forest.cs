using MonsterModels;

namespace Heroes
{
    public class Forest
    {
        public static int ForestStart()
        {
            Console.WriteLine("You have entered the forest!");
            Console.WriteLine("In the forest you have 3 options:");
            Console.WriteLine("1. Fight a goblin");
            Console.WriteLine("2. Fight a troll");
            Console.WriteLine("3. Fight a dragon");
            do
            {
                var input = int.TryParse(Console.ReadLine(), out var iresult) ? iresult : 0;
                switch (input)
                {
                    case 1:
                        var goblin = MonsterCreation.goblin;
                        Attack.AttackMonster(goblin);
                        break;
                    case 2:
                        //Troll.TrollStart();
                        break;
                    case 3:
                        //Dragon.DragonStart();
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