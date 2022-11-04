namespace MonsterModels
{
    public interface IMonster
    {
        string Name { get; set; }
        int Health { get; set; }
        int Damage { get; set; }
        int Armor { get; set; }
        int Level { get; set; }
        int Experience { get; set; }
        int Gold { get; set; }
        int Strength { get; set; }

        string Attack(IMonster monster);

    }
}
