namespace CoconutIsland.Api.V1.Models
{
    public class ProduceDto
    {
        public ProduceDto(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public int Id { get; }
        public string Name { get; }
    }
}