using HeroModels;

namespace SolutionItems
{
    public interface IHero
    {

        public string? Name { get; set; }
        public string Class { get; set; }
        public int Health { get; set; }
        public int Damage { get; set; }
        public int Armor { get; set; }
        public int Level { get; set; }
        public int Experience { get; set; }
        public int Gold { get; set; }
        public int Strength { get; set; }
        public List<Weapon> WeaponSack { get; set; }
        public List<Food> FoodSack { get; set; }

        public string Attack(IHero hero);
        public string LevelUp(IHero hero);
        public int GainExperience(IHero currentCharacter, int experience);
        public int GainGold(IHero currentCharacter, int gold);
        public string GainHealth(IHero hero, int health);
        public string LoseHealth(IHero hero, int health, int damage);


    }
}
