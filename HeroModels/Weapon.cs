namespace HeroModels
{

    public class Weapon
    {
        static Random rand = new Random(Guid.NewGuid().GetHashCode());

        public string Name { get; set; }
        public int Damage { get; set; }
        public int Level { get; set; }
        public string Rarity { get; set; }
        public string Type { get; set; }

        public Weapon(string name, int damage, int level, string rarity, string type)
        {
            Name = name;
            Damage = damage;
            Level = level;
            Rarity = rarity;
            Type = type;
        }

        public Weapon()
        {
        }

        /*Magic weapons*/
        public static Weapon ElectricityWand =
            new(name: "Electricity Wand", damage: 5, level: 1, rarity: "Common", type: "Magic");

        public static Weapon ElementalStaff =
            new(name: "Elemental Staff", damage: 30, level: 5, rarity: "Common", type: "Magic");

        public int CalculateDamage(Weapon weapon)
        {

            Random random = new();
            var damage = random.Next(weapon.Damage);

            return damage;
        }


    }
}
