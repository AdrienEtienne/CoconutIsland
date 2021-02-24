namespace CoconutIsland.Ingredient.Infrastructure.Entities
{
    public class ProduceEntity
    {
        public ProduceEntity(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }


        public int Id { get; }

        public string Name { get; }
    }
}