namespace MonsterModels
{
    public class Dragon
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Damage { get; set; }
        public int Armor { get; set; }
        public int Level { get; set; }
        public int Experience { get; set; }
        public int Gold { get; set; }
        public int Strength { get; set; }
        public string Attack(IMonster monster)
        {
            monster.Health -= Damage;
            return $"You have dealt {Damage} damage. The Dragon is now at {monster.Health}!";
        }

    }
}
