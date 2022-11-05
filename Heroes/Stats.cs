using static Heroes.SelectCharacter;

namespace Heroes
{
    public class Stats
    {
        public static int StatsStart()
        {
            Console.WriteLine("You have chosen to check your character's stats!");
            PrintStats();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
            return Adventure.AdventureStart();
        }
        public static void PrintStats()
        {
            Console.WriteLine("Your character's stats are:");
            Console.WriteLine($"Name: {CurrentCharacter.Name}");
            Console.WriteLine($"Health: {CurrentCharacter.Health}");
            Console.WriteLine($"Damage: {CurrentCharacter.Damage}");
            Console.WriteLine($"Armor: {CurrentCharacter.Armor}");
            Console.WriteLine($"Level: {CurrentCharacter.Level}");
            Console.WriteLine($"Experience: {CurrentCharacter.Experience}");
            Console.WriteLine($"Gold: {CurrentCharacter.Gold}");
            Console.WriteLine($"Strength: {CurrentCharacter.Strength}");
            Console.WriteLine($"Weapons: {CurrentCharacter.Inventory.ToList().Count}");
            foreach (var weapon in CurrentCharacter.Inventory)
            {
                Console.WriteLine($"[{weapon.Rarity}] {weapon.Name} | Damage: {weapon.Damage} | Type: {weapon.Type} | Level: {weapon.Level} | Uses Left: {weapon.Degradation}");

            }
        }
    }
}
