using CoconutIsland.Structure;

namespace CoconutIsland.Ingredient.Domain.StrongTypes
{
    public class NameType : StrongType
    {
        public NameType(string name)
        {
            this.Name = name;
        }


        public string Name { get; }


        public override string ToString()
        {
            return this.Name;
        }
    }
}