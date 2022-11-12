using SolutionItems;

namespace HeroModels
{
    public class Mage : IHero
    {
        public Mage(string? name)
        {
            Name = name;
        }

        public Mage()
        {
        }

        public override string? Name { get; set; }
        public override string Class { get; set; }

        public override int Health { get; set; }

        public override int Damage { get; set; }

        public override int Armor
        { get; set; }
        public override int Level
        { get; set; }
        public override int Experience
        { get; set; }
        public override int Gold
        { get; set; }
        public override int Strength
        { get; set; }

        public override List<Weapon> WeaponSack { get; set; }
        public override List<Food> FoodSack { get; set; }

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
