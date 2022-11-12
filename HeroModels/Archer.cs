using SolutionItems;

namespace HeroModels
{
    public class Archer : IHero
    {
        public override string? Name { get; set; }
        public override string Class { get; set; }

        public override int Health
        { get; set; }
        public override int Damage
        { get; set; }
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
            throw new NotImplementedException();
        }

        public override int GainGold(IHero currentCharacter, int gold)
        {
            throw new NotImplementedException();
        }

        public override string GainHealth(IHero hero, int health)
        {
            throw new NotImplementedException();
        }
        public override string LoseHealth(IHero hero, int health, int damage)
        {
            hero.Health -= damage;
            return $"You have taken {damage} damage. Your health is now at {hero.Health}!";
        }

        public override string LevelUp(IHero hero)
        {
            hero.Level += 1;
            var level = hero.Level;
            return $"Congratulations! You are now level {Level}";
        }

        public override int GainExperience(IHero currentCharacter, int experience)
        {
            throw new NotImplementedException();
        }
    }
}
