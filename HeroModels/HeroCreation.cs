namespace HeroModels
{
    public class HeroCreation
    {
        public Mage mage = new() { Name = "", Class = "Mage", Health = 100, Damage = 10, Armor = 5, Level = 1, Experience = 0, Gold = 0, Strength = 10, Inventory = new List<Weapons> { Weapons.staffOfWeakness, Weapons.staffOfFatigue } };
        public Archer archer = new() { Name = "", Class = "Archer", Health = 100, Damage = 10, Armor = 5, Level = 1, Experience = 0, Gold = 0, Strength = 10, Inventory = new List<Weapons>() };
    }
}
