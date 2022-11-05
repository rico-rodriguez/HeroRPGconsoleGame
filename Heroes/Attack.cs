﻿using MonsterModels;
using static Heroes.SelectCharacter;
namespace Heroes
{
    public class Attack
    {
        //static Random rand = new Random(Guid.NewGuid().GetHashCode());

        public static int AttackMonster(MonsterCreation monster)
        {
            while (true)
            {
                Console.WriteLine($"You open your inventory to see you have {CurrentCharacter.Inventory.ToList().Count} weapons.");
                if (CurrentCharacter.Inventory.ToList().Count == 0)
                {
                    Console.WriteLine($"You have no items in your inventory. You cannot attack the {monster.Name}.");
                    Console.WriteLine("Press any key to continue your adventure!");
                    Console.ReadKey();
                    Adventure.AdventureStart();
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
                            UseWeapon(monster);
                            break;
                        case 2:
                            Console.WriteLine("Coward!");
                            Console.WriteLine("While fleeing you trip on a rock and injure yourself.");
                            CurrentCharacter.LoseHealth(CurrentCharacter, CurrentCharacter.Health, random.Next(5, 15));
                            Console.WriteLine($"You have {CurrentCharacter.Health} health left.");
                            Console.WriteLine("Press any key to continue your adventure!");
                            Console.ReadKey();
                            Adventure.AdventureStart();
                            break;
                        default:
                            Console.WriteLine("You have not selected a valid option. Please try again.");
                            continue;
                    }

                    return input;
                }


            }
        }

        private static void UseWeapon(MonsterCreation monster)
        {
            while (true)
            {
                Console.WriteLine("Which weapon would you like to use?");
                var weapon = 1;
                foreach (var item in CurrentCharacter.Inventory)
                {
                    Console.WriteLine($"{item.Name}, Damage: {item.Damage}, Level: {item.Level}, Rarity: {item.Rarity}, Uses Left: {item.Degradation}");
                    weapon++;
                }
                var input = int.TryParse(Console.ReadLine(), out var iresult) ? iresult : 0;
                var weaponChoice = CurrentCharacter.Inventory.ToList()[input - 1];
                Console.WriteLine($"You have chosen to use {weaponChoice.Name}.");
                Console.WriteLine($"You attack the {monster.Name}!");
                var damage = weaponChoice.CalculateDamage(weaponChoice);
                monster.LoseHealth(monster, damage);
                weaponChoice.Degradation--;
                Console.WriteLine($"You deal {damage} damage to the {monster.Name}, he now has {monster.Health} health left.");
                Console.WriteLine($"Your weapon has {weaponChoice.Degradation} uses left.");
                if (weaponChoice.Degradation == 0)
                {
                    Console.WriteLine($"Your {weaponChoice.Name} has broken! A magical force teleports you back to your village.");
                    CurrentCharacter.Inventory.Remove(weaponChoice);
                    Adventure.AdventureStart();
                }
                if (monster.Health < 1)
                {
                    Console.WriteLine($"You have defeated the {monster.Name}!");
                    Console.WriteLine("You loot the monster's body and find:");
                    Console.WriteLine($"{monster.Gold} gold");
                    Console.WriteLine($"{monster.Experience} experience");
                    CurrentCharacter.GainGold(CurrentCharacter, monster.Gold);
                    CurrentCharacter.GainExperience(CurrentCharacter, monster.Experience);
                    Console.WriteLine("Press any key to continue your adventure!");
                    Console.ReadKey();
                    Adventure.AdventureStart();
                }
                Console.WriteLine($"The {monster.Name} attacks you!");
                var monsterDamage = monster.AttackPlayer(monster, CurrentCharacter);
                Console.WriteLine($"The {monster.Name} deals {monsterDamage} damage to you.");
                CurrentCharacter.LoseHealth(CurrentCharacter, CurrentCharacter.Health, (int)monsterDamage);
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
                        Adventure.AdventureStart();
                        break;
                }
            }
        }
    }
}
