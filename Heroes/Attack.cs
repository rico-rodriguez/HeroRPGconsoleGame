using HeroesDB;
using Microsoft.EntityFrameworkCore;
using MonsterModels;
using UserRegistration;
namespace Heroes
{
    public class Attack
    {
        private string _cnstr;
        private static DbContextOptionsBuilder _optionsBuilder;

        public Attack()
        {
            _cnstr = Program._configuration["ConnectionStrings:HeroesDB"];
            _optionsBuilder = new DbContextOptionsBuilder<HeroesDBContext>().UseSqlServer(_cnstr);
        }
        public int AttackMonster(MonsterCreation monster, User user, Hero hero)
        {
            while (true)
            {
                var context = new HeroesDBContext(_optionsBuilder.Options);
                var CurrentCharacter = SelectCharacter.CurrentHero;
                Console.WriteLine($"You open your inventory to see you have {CurrentCharacter.WeaponSack.ToList().Count} weapons.");
                if (CurrentCharacter.WeaponSack.ToList().Count == 0)
                {
                    Console.WriteLine($"You have no items in your inventory. You cannot attack the {monster.Name}.");
                    Console.WriteLine("Press any key to continue your adventure!");
                    Console.ReadKey();
                    Adventure.AdventureStart(user, hero);
                }
                else
                {
                    Console.WriteLine("1. Use a weapon from your inventory");
                    Console.WriteLine("2. Flee");
                    int input = int.TryParse(Console.ReadLine(), out var result) ? result : 0;
                    var random = new Random();
                    switch (input)
                    {
                        case 1:
                            UseWeapon(monster, user, hero);
                            break;
                        case 2:
                            Console.WriteLine("Coward!");
                            Console.WriteLine("While fleeing you trip on a rock and injure yourself.");
                            context.User.Update(user);
                            CurrentCharacter.LoseHealth(CurrentCharacter, CurrentCharacter.Health, random.Next(5, 15));
                            context.SaveChanges();

                            Console.WriteLine($"You have {CurrentCharacter.Health} health left.");
                            Console.WriteLine("Press any key to continue your adventure!");
                            Console.ReadKey();
                            Adventure.AdventureStart(user, hero);
                            break;
                        default:
                            Console.WriteLine("You have not selected a valid option. Please try again.");
                            continue;
                    }

                    return input;
                }


            }
        }

        private static void UseWeapon(MonsterCreation monster, User user, Hero hero)
        {
            while (true)
            {
                var context = new HeroesDBContext(_optionsBuilder.Options);
                var CurrentCharacter = SelectCharacter.CurrentHero;
                Console.WriteLine("Which weapon would you like to use?");
                var weapon = 1;
                foreach (var item in CurrentCharacter.WeaponSack)
                {
                    Console.WriteLine($"{item.Name}, Damage: {item.Damage}, Level: {item.Level}, Rarity: {item.Rarity}, Uses Left: {item.Degradation}");
                    weapon++;
                }
                var input = int.TryParse(Console.ReadLine(), out var iresult) ? iresult : 0;
                var weaponChoice = CurrentCharacter.WeaponSack.ToList()[input - 1];
                Console.WriteLine($"You have chosen to use {weaponChoice.Name}.");
                Console.WriteLine($"You attack the {monster.Name}!");
                var damage = weaponChoice.CalculateDamage(weaponChoice);
                monster.LoseHealth(monster, damage);
                context.User.Update(user);
                weaponChoice.Degradation--;
                context.SaveChanges();
                Console.WriteLine($"You deal {damage} damage to the {monster.Name}, he now has {monster.Health} health left.");
                Console.WriteLine($"Your weapon has {weaponChoice.Degradation} uses left.");
                if (weaponChoice.Degradation == 0)
                {
                    Console.WriteLine($"Your {weaponChoice.Name} has broken! A magical force teleports you back to your village.");
                    context.User.Update(user);
                    CurrentCharacter.WeaponSack.Remove(weaponChoice);
                    context.SaveChanges();
                    Adventure.AdventureStart(user, hero);
                }
                if (monster.Health < 1)
                {
                    Console.WriteLine($"You have defeated the {monster.Name}!");
                    Console.WriteLine("You loot the monster's body and find:");
                    Console.WriteLine($"{monster.Gold} gold");
                    Console.WriteLine($"{monster.Experience} experience");
                    context.User.Update(user);
                    CurrentCharacter.GainGold(CurrentCharacter, monster.Gold);
                    CurrentCharacter.GainExperience(CurrentCharacter, monster.Experience);
                    context.SaveChanges();
                    Console.WriteLine("Press any key to continue your adventure!");
                    Console.ReadKey();
                    Adventure.AdventureStart(user, hero);
                }
                Console.WriteLine($"The {monster.Name} attacks you!");
                context.User.Update(user);
                var monsterDamage = monster.AttackPlayer(monster, CurrentCharacter);
                Console.WriteLine($"The {monster.Name} deals {monsterDamage} damage to you.");
                CurrentCharacter.LoseHealth(CurrentCharacter, CurrentCharacter.Health, (int)monsterDamage);
                context.SaveChanges();
                Console.WriteLine($"You have {CurrentCharacter.Health} health left.");
                if (CurrentCharacter.Health <= 0)
                {
                    Console.WriteLine("You have died.");
                    Console.WriteLine("Press any key to exit the game.");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
                Console.WriteLine("Do you want to attack again?");
                Console.WriteLine("1. Yes");
                Console.WriteLine("2. No");
                var attackAgain = int.TryParse(Console.ReadLine(), out var iresult2) ? iresult2 : 0;
                while (attackAgain is not (1 or 2))
                {
                    Console.WriteLine("You have not selected a valid option. Please try again.");
                    attackAgain = int.TryParse(Console.ReadLine(), out var iresult3) ? iresult3 : 0;
                }
                switch (attackAgain)
                {
                    case 1:
                        continue;
                    case 2:
                        Console.WriteLine("Press any key to continue your adventure!");
                        Console.ReadKey();
                        Adventure.AdventureStart(user, hero);
                        break;
                }
            }
        }
    }
}
