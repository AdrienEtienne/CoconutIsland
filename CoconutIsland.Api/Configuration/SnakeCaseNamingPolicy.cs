using System.Text.Json;
using Newtonsoft.Json.Serialization;

namespace CoconutIsland.Api.Configuration
{
    public class SnakeCaseNamingPolicy : JsonNamingPolicy
    {
        private readonly SnakeCaseNamingStrategy _newtonsoftSnakeCaseNamingStrategy
            = new();

        public static SnakeCaseNamingPolicy Instance { get; } = new();

        public override string ConvertName(string name)
        {
            return this._newtonsoftSnakeCaseNamingStrategy.GetPropertyName(name, false);
        }
    }
}