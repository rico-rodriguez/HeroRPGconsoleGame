using SolutionItems;

namespace MonsterModels;

public class MonsterCreation
{
    public static IHero CurrentCharacter;

    public string Name { get; set; }
    public int Health { get; set; }
    public int Damage { get; set; }
    public int Armor { get; set; }
    public int Level { get; set; }
    public int Experience { get; set; }
    public int Gold { get; set; }
    public int Strength { get; set; }

    public static MonsterCreation goblin = new("Goblin", 20, 5, 2, 1, 50, 50, 5);
    public static MonsterCreation troll = new("Troll", 50, 15, 6, 1, 100, 100, 10);
    public static MonsterCreation dragon = new("Dragon", 100, 25, 10, 1, 200, 200, 20);

    //MonsterCreation troll = new() { Name = "Troll", Health = 50, Damage = 5, Armor = 5, Level = 5, Experience = 100, Gold = 100, Strength = 10 };
    //MonsterCreation dragon = new() { Name = "Dragon", Health = 100, Damage = 10, Armor = 10, Level = 10, Experience = 200, Gold = 200, Strength = 15 };
    public MonsterCreation(string name, int health, int damage, int armor, int level, int experience, int gold,
        int strength)
    {
        Name = name;
        Health = health;
        Damage = damage;
        Armor = armor;
        Level = level;
        Experience = experience;
        Gold = gold;
        Strength = strength;
    }


    public int LoseHealth(MonsterCreation monster, int damage)
    {
        return monster.Health -= damage;
    }

    public double AttackPlayer(MonsterCreation monster, IHero hero)
    {
        Random random = new();
        var damage = random.Next(monster.Damage);

        hero.Health -= damage;
        return damage;
    }
}