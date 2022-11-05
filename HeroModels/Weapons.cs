namespace HeroModels
{

    public class Weapons
    {
        static Random rand = new Random(Guid.NewGuid().GetHashCode());

        public string Name { get; set; }
        public int Damage { get; set; }
        public int Level { get; set; }

        public Weapons(string name, int damage, int level)
        {

            Name = name;
            Damage = damage;
            Level = level;
        }

        /*Magic weapons*/
        public static Weapons staffOfWeakness =
            new(name: "Staff of Weakness", damage: 5, level: 1);

        public static Weapons staffOfFatigue =
            new(name: "Staff of Fatigue ", damage: 30, level: 5);

        public int CalculateDamage(Weapons weapon)
        {

            Random random = new();
            var damage = random.Next(weapon.Damage);

            return damage;
        }


    }
}
