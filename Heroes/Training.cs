namespace Heroes
{
    public class Training
    {

        public static int TrainingStart()
        {
            Console.WriteLine("You have chosen to train your character!");
            Console.WriteLine("You have 2 options:");
            Console.WriteLine("1. Train your strength");
            Console.WriteLine("2. Take a rest to replenish your health");
            var input = Convert.ToInt32(Console.ReadLine());
            return input switch
            {
                1 => StrengthStart(),
                2 => HealthStart(),
                _ => int.TryParse("You have not selected a valid option. Please try again.", out var result) ? result : 0
            };
        }

        private static int HealthStart()
        {
            var CurrentCharacter = SelectCharacter.CurrentHero;
            CurrentCharacter.GainHealth(CurrentCharacter, 100);
            Console.WriteLine($"You have replenished your health! You are now at {CurrentCharacter.Health}");
            Console.WriteLine("Press any key to continue your adventure!");
            Console.ReadKey();
            return Adventure.AdventureStart(SelectCharacter.CurrentUser, SelectCharacter.CurrentHero);
        }

        private static int StrengthStart()
        {
            var CurrentCharacter = SelectCharacter.CurrentHero;
            Random random = new Random();
            CurrentCharacter.Strength += random.Next(3, 5);
            Console.WriteLine("You have trained your strength!");
            Console.WriteLine($"You are now level {CurrentCharacter.Strength}!");
            Console.WriteLine("Press any key to continue your adventure!");
            Console.ReadKey();
            return Adventure.AdventureStart(SelectCharacter.CurrentUser, SelectCharacter.CurrentHero);

        }

    }
}
