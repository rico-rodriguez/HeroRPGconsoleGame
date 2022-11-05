namespace Heroes
{
    public class Adventure
    {
        public static int AdventureStart()
        {
            Console.WriteLine("You have 5 options:");
            Console.WriteLine("1. Go to the forest");
            Console.WriteLine("2. Go to the mountains");
            Console.WriteLine("3. Go to the sea");
            Console.WriteLine("4. Train your character");
            Console.WriteLine("5. Check your character's stats");
            do
            {
                var input = int.TryParse(Console.ReadLine(), out var iresult) ? iresult : 0;
                switch (input)
                {
                    case 1:
                        Forest.Start();
                        break;
                    case 2:
                        Mountain.Start();
                        break;
                    case 3:
                        //Sea.SeaStart();
                        break;
                    case 4:
                        Training.TrainingStart();
                        break;
                    case 5:
                        Stats.StatsStart();
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