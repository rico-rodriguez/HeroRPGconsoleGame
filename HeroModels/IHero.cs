using HeroModels;
using System.ComponentModel.DataAnnotations;

namespace SolutionItems
{
    public abstract class IHero
    {
        [Key]
        public int Id { get; set; }
        public abstract string? Name { get; set; }
        public abstract string Class { get; set; }
        public abstract int Health { get; set; }
        public abstract int Damage { get; set; }
        public abstract int Armor { get; set; }
        public abstract int Level { get; set; }
        public abstract int Experience { get; set; }
        public abstract int Gold { get; set; }
        public abstract int Strength { get; set; }
        public abstract List<Weapon> WeaponSack { get; set; }
        public abstract List<Food> FoodSack { get; set; }
        public abstract string Attack(IHero hero);
        public abstract string LevelUp(IHero hero);
        public abstract int GainExperience(IHero currentCharacter, int experience);
        public abstract int GainGold(IHero currentCharacter, int gold);
        public abstract string GainHealth(IHero hero, int health);
        public abstract string LoseHealth(IHero hero, int health, int damage);
    }
}
