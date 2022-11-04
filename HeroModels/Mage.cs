using SolutionItems;

namespace HeroModels
{
    public class Mage : IHero
    {
        public string? Name { get; set; }
        public string Class { get; set; }

        public int Health { get; set; }

        public int Damage { get; set; }

        public int Armor
        { get; set; }
        public int Level
        { get; set; }
        public int Experience
        { get; set; }
        public int Gold
        { get; set; }
        public int Strength
        { get; set; }

        public List<Weapons> Inventory { get; set; }

        public string Attack(IHero hero)
        {
            return "";
        }

        public int GainExperience(IHero hero, int experience)
        {
            return hero.Experience += experience;
        }

        public int GainGold(IHero hero, int gold)
        {
            return hero.Gold += gold;
        }

        public string GainHealth(IHero hero, int health)
        {
            hero.Health += health;
            if (hero.Health >= 100)
            {
                hero.Health = 100;
            }
            return $"Your health is now at {hero.Health}!";
        }
        public string LoseHealth(IHero hero, int health, int damage)
        {
            hero.Health -= damage;
            if (hero.Health <= 0)
            {
                Environment.Exit(1);
                return "You have died.";
            }
            return $"You have taken {damage} damage. Your health is now at {hero.Health}!";
        }

        public string LevelUp(IHero hero)
        {
            hero.Level += 1;
            var level = hero.Level;
            return $"Congratulations! You are now level {Level}";
        }

    }
}
