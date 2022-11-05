namespace Heroes
{
    public class Mountain
    {
        public static void Start()
        {
            Console.WriteLine("You have entered the mountains!");
            Console.WriteLine("Here you can loot a chest to get a weapon.");
            Console.WriteLine("Be warned, This is a [dangerous] activity!");
            Console.WriteLine("Press any key to continue!");
            Console.ReadKey();
            Training.Scavenge();
        }

    }
}
