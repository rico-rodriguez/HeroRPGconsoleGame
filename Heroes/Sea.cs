using HeroModels;
using static Heroes.SelectCharacter;

namespace Heroes
{
    public class Sea
    {
        public static void SeaStart()
        {
            Console.WriteLine("Press any key to set sail and catch some fish!");
            Console.ReadKey();
            Console.WriteLine("You set sail and catch some fish!");
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
            if (CurrentCharacter.FoodSack.ToList().Contains(Food.trout))
            {
                Food.trout.Quantity += 1;
            }
            if (CurrentCharacter.FoodSack.ToList().Contains(Food.salmon))
            {
                Food.salmon.Quantity += 1;
            }
            else if (!CurrentCharacter.FoodSack.ToList().Contains(Food.trout))
            {
                CurrentCharacter.FoodSack.Add(Food.trout);
            }
            else if (!CurrentCharacter.FoodSack.ToList().Contains(Food.salmon))
            {
                CurrentCharacter.FoodSack.Add(Food.salmon);
            }
            foreach (var food in CurrentCharacter.FoodSack)
            {
                Console.WriteLine($"You now have: ({food.Quantity}) [{food.Name}] | Healing [{food.Heal}] health each");
            }


        }
    }
}
