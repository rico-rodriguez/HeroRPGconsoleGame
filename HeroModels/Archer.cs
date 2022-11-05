using SolutionItems;

namespace HeroModels
{
    public class Archer : IHero
    {
        public string? Name { get; set; }
        public string Class { get; set; }

        public int Health
        { get; set; }
        public int Damage
        { get; set; }
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

        public List<Weapon> Inventory { get; set; }

        public string Attack(IHero hero)
        {
            throw new NotImplementedException();
        }

        public int GainGold(IHero currentCharacter, int gold)
        {
            throw new NotImplementedException();
        }

        public string GainHealth(IHero hero, int health)
        {
            throw new NotImplementedException();
        }
        public string LoseHealth(IHero hero, int health, int damage)
        {
            hero.Health -= damage;
            return $"You have taken {damage} damage. Your health is now at {hero.Health}!";
        }

        public string LevelUp(IHero hero)
        {
            hero.Level += 1;
            var level = hero.Level;
            return $"Congratulations! You are now level {Level}";
        }

        public int GainExperience(IHero currentCharacter, int experience)
        {
            throw new NotImplementedException();
        }
    }
}
