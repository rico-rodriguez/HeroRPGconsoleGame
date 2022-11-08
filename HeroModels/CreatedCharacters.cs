namespace HeroModels
{
    public class CreatedCharacters : HeroCreation
    {

        public static List<Mage> mageList = new List<Mage>();
        public static List<Archer> archerList = new List<Archer>();

        public static void AddMage(Mage mage)
        {
            mageList.Add(mage);
        }

        public static void AddArcher(Archer archer)
        {
            archerList.Add(archer);
        }

        public static void RemoveMage(Mage mage)
        {
            mageList.Remove(mage);
        }

        public static void RemoveArcher(Archer archer)
        {
            archerList.Remove(archer);
        }

        public static void PrintMages()
        {
            foreach (var mage in mageList)
            {
                Console.WriteLine(mage.Name);
            }
        }

        public static void PrintArchers()
        {
            foreach (var archer in archerList)
            {
                Console.WriteLine(archer.Name);
            }
        }

        public static void PrintAllCharacters()
        {
            Console.WriteLine("Mages:");
            PrintMages();
            Console.WriteLine("Archers:");
            PrintArchers();
        }

        public static void PrintAllCharactersWithDetails()
        {
            Console.WriteLine("Mages:");
            foreach (var mage in mageList)
            {
                Console.WriteLine(mage.Name);
                Console.WriteLine(mage.Class);
                Console.WriteLine(mage.Health);
                Console.WriteLine(mage.Damage);
                Console.WriteLine(mage.Armor);
                Console.WriteLine(mage.Level);
                Console.WriteLine(mage.Experience);
                Console.WriteLine(mage.Gold);
                Console.WriteLine(mage.Strength);
                Console.WriteLine(mage.WeaponSack);
                Console.WriteLine(mage.FoodSack);
            }
            Console.WriteLine("Archers:");
            foreach (var archer in archerList)
            {
                Console.WriteLine(archer.Name);
                Console.WriteLine(archer.Class);
                Console.WriteLine(archer.Health);
                Console.WriteLine(archer.Damage);
                Console.WriteLine(archer.Armor);
                Console.WriteLine(archer.Level);
                Console.WriteLine(archer.Experience);
                Console.WriteLine(archer.Gold);
                Console.WriteLine(archer.Strength);
                Console.WriteLine(archer.WeaponSack);
                Console.WriteLine(archer.FoodSack);
            }
        }
    }
}
