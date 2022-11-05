﻿using HeroModels;
using SolutionItems;

namespace Heroes
{
    public class SelectCharacter
    {
        private static readonly HeroCreation heroCreation = new();
        private static readonly Mage mage = heroCreation.mage;
        private static readonly Archer archer = heroCreation.archer;
        public static IHero CurrentCharacter;


        public static void CharacterSelection()
        {

            Console.WriteLine("Welcome to the game! Please select a character to play as:");
            Console.WriteLine("1. Mage");
            Console.WriteLine("2. Archer");
            var input = Console.ReadLine();
            SetSelectedCharacter(int.TryParse(input, out var result) ? result : 0);
            Console.WriteLine($"You chose to play as a  {CurrentCharacter.Class}.");
            while (string.IsNullOrEmpty(CurrentCharacter.Name))
            {
                Console.WriteLine($"Please start by giving your character a name:");
                CurrentCharacter.Name = Console.ReadLine();
            }
            Stats.PrintStats();
            Console.WriteLine("Press any key to begin your adventure!");
            Console.ReadKey();

        }



        public static IHero SetSelectedCharacter(int userChoice)
        {
            switch (userChoice)
            {
                case 1:
                    CurrentCharacter = mage;
                    break;
                case 2:
                    CurrentCharacter = archer;
                    break;
                default:
                    Console.WriteLine("You have not selected a valid option. Please try again.");
                    CharacterSelection();
                    break;
            }

            return CurrentCharacter;
        }
    }
}
