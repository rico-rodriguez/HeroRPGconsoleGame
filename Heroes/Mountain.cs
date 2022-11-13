using HeroesDB;
using HeroModels;
using Microsoft.EntityFrameworkCore;
using UserRegistration;

namespace Heroes
{
    public class Mountain
    {
        private string _cnstr;
        private static DbContextOptionsBuilder _optionsBuilder;

        public Mountain()
        {
            _cnstr = Program._configuration["ConnectionStrings:HeroesDB"];
            _optionsBuilder = new DbContextOptionsBuilder<HeroesDBContext>().UseSqlServer(_cnstr);
        }
        public static void Start(User user, Hero hero)
        {
            Console.WriteLine("You have entered the mountains!");
            Console.WriteLine("Here you can loot a chest to get a weapon.");
            Console.WriteLine("Be warned, This is a [dangerous] activity!");
            Console.WriteLine("Press any key to continue!");
            Console.ReadKey();
            Scavenge(user, hero);
        }
        public static void Scavenge(User user, Hero hero)
        {
            var mountain = new Mountain();
            var context = new HeroesDBContext(_optionsBuilder.Options);
            Console.WriteLine("Type 'confirm' to scavenge for items.");
            Console.WriteLine("Type anything else to flee.");
            var input = Console.ReadLine();
            switch (input)
            {
                case "confirm":
                    {
                        var CurrentCharacter = SelectCharacter.CurrentHero;
                        var loggedinuser = SelectCharacter.CurrentUser;
                        //Damage player for a percentage of their health
                        var damage = CurrentCharacter.Health - (CurrentCharacter.Health * 0.70);
                        context.User.Update(user);
                        CurrentCharacter.LoseHealth(CurrentCharacter, CurrentCharacter.Health, (int)damage);
                        context.SaveChanges();
                        Console.WriteLine($"You have lost {damage} health.");
                        Console.WriteLine($"You have {CurrentCharacter.Health} health left.");
                        Console.WriteLine("Press any key to collect your loot!");
                        Console.ReadKey();
                        //Generate a random weapon
                        Random random = new Random();
                        var weapon = new Weapon();
                        var weaponName = new List<string> { "Sword", "Axe", "Mace", "Dagger", "Bow", "Staff", "Spear", "Wand", "Hammer", "Sickle" };
                        var weaponType = new List<string> { "Heavy", "Defensive", "Offensive", "Light", "Damaged", "Reinforced", "Magic", "Wooden", "Metallic", "Colorful" };
                        var weaponLevel = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
                        var weaponDamage = new List<int> { 5, 10, 15, 20, 25, 30, 35, 40, 45, 50 };
                        var weaponRarity = new List<string> { "Common", "Uncommon", "Rare", "Epic", "Legendary" };
                        var weaponRarityChance = new List<int> { 70, 15, 10, 4, 1 };
                        var weaponRarityChanceTotal = weaponRarityChance.Sum();
                        var weaponRarityChanceRandom = random.Next(1, weaponRarityChanceTotal + 1);
                        var weaponRarityChanceIndex = 0;
                        for (var i = 0; i < weaponRarityChance.Count; i++)
                        {
                            weaponRarityChanceIndex += weaponRarityChance[i];
                            if (weaponRarityChanceRandom <= weaponRarityChanceIndex)
                            {
                                weapon.Rarity = weaponRarity[i];
                                break;
                            }
                        }
                        weapon.Name = weaponName[random.Next(0, weaponName.Count)];
                        weapon.Degradation = random.Next(1, 15);
                        weapon.Type = weaponType[random.Next(0, weaponType.Count)];
                        weapon.Damage = weaponDamage[random.Next(0, weaponDamage.Count)];
                        weapon.Level = weaponLevel[random.Next(0, weaponLevel.Count)];
                        context.User.Update(loggedinuser);
                        context.Hero.Update(CurrentCharacter);
                        CurrentCharacter.WeaponSack.Add(weapon);
                        context.SaveChanges();
                        Console.WriteLine($"You have found a [level {weapon.Level}] [{weapon.Rarity}] ({weapon.Type} {weapon.Name})! It has {weapon.Degradation} uses left.");
                        Console.WriteLine("Press any key to continue your adventure!");
                        Console.ReadKey();
                        Adventure.AdventureStart(user, hero);
                        break;
                    }
                default:
                    Adventure.AdventureStart(user, hero);
                    break;
            }
        }
    }
}
