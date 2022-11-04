namespace Heroes
{
    public class Stats
    {
        public static int StatsStart()
        {
            Console.WriteLine("You have chosen to check your character's stats!");
            SelectCharacter.PrintStats();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
            return Adventure.AdventureStart();
        }

    }
}
