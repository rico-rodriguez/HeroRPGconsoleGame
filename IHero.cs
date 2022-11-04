namespace SolutionItems
{
    public interface IHero
    {

        public string Name { get; set; }
        public int Health { get; set; }
        public int Damage { get; set; }
        public int Armor { get; set; }
        public int Level { get; set; }
        public int Experience { get; set; }
        public int Gold { get; set; }
        public int Strength { get; set; }

        public void Attack(IHero hero);
        public void Defend(IHero hero);
        public void LevelUp();
        public void GainExperience(int experience);
        public void GainGold(int gold);
        public void GainHealth(int health);
        public void LoseHealth(int health);
        public void GainArmor(int armor);
        public void LoseArmor(int armor);
        public void GainDamage(int damage);
        public void LoseDamage(int damage);
        public void GainStrength(int strength);
        public void LoseStrength(int strength);


    }
}
