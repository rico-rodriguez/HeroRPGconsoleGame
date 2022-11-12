using HeroModels;
using SolutionItems;
using System.ComponentModel.DataAnnotations;

namespace UserRegistration
{
    public class Hero : IHero
    {
        public Hero()
        {
        }
        [Key]
        public new int Id { get; set; }
        public override string? Name { get; set; } = "Harry Potter";
        public override string Class { get; set; } = "Mage";

        public override int Health { get; set; } = 100;

        public override int Damage { get; set; } = 10;

        public override int Armor
        { get; set; } = 5;

        public override int Level
        { get; set; } = 1;

        public override int Experience
        { get; set; } = 0;

        public override int Gold
        { get; set; } = 0;

        public override int Strength
        { get; set; } = 10;

        public virtual User User { get; set; }

        public override List<Weapon> WeaponSack { get; set; } = new() { Weapon.ElectricityWand, Weapon.ElementalStaff };
        public override List<Food> FoodSack { get; set; } = new() { Food.trout, Food.salmon };

        public override string Attack(IHero hero)
        {
            return "";
        }

        public override int GainExperience(IHero hero, int experience)
        {
            return hero.Experience += experience;
        }

        public override int GainGold(IHero hero, int gold)
        {
            return hero.Gold += gold;
        }

        public override string GainHealth(IHero hero, int health)
        {
            hero.Health += health;
            if (hero.Health >= 100)
            {
                hero.Health = 100;
            }
            return $"Your health is now at {hero.Health}!";
        }
        public override string LoseHealth(IHero hero, int health, int damage)
        {
            hero.Health -= damage;
            if (hero.Health <= 0)
            {
                Environment.Exit(1);
                return "You have died.";
            }
            return $"You have taken {damage} damage. Your health is now at {hero.Health}!";
        }

        public override string LevelUp(IHero hero)
        {
            hero.Level += 1;
            var level = hero.Level;
            return $"Congratulations! You are now level {Level}";
        }
    }
}
