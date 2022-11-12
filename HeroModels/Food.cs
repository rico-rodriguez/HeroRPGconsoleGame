namespace HeroModels
{

    public class Food
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Heal { get; set; }
        public int Quantity { get; set; }



        public Food(string name, int heal, int quantity)
        {
            Name = name;
            Heal = heal;
            Quantity = quantity;
        }

        public static Food trout =
            new(name: "Trout", heal: 5, quantity: 1);

        public static Food salmon =
            new(name: "Salmon", heal: 7, quantity: 1);


    }
}