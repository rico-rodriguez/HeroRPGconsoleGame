namespace HeroModels
{
    public class Weapons
    {

        public string Name { get; set; }
        public int Damage { get; set; }
        public int Level { get; set; }

        public Weapons(string name, int damage, int level)
        {
            Random random = new();
            Name = name;
            Damage = random.Next(damage);
            Level = level;
        }

        /*Magic weapons*/
        public static Weapons staffOfWeakness =
            new(name: "Staff of Weakness", damage: 10, level: 1);

        public static Weapons staffOfFatigue =
            new(name: "Staff of Fatigue ", damage: 30, level: 5);

    }
}
