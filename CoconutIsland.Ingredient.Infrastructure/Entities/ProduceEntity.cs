namespace CoconutIsland.Ingredient.Infrastructure.Entities
{
    public class ProduceEntity
    {
        public int Id { get; }

        public string Name { get; }

        public ProduceEntity(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}