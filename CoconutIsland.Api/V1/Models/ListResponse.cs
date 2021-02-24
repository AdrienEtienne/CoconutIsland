using System.Collections.Generic;

namespace CoconutIsland.Api.V1.Models
{
    public class ListResponse<T>
    {
        public ListResponse(IEnumerable<T> data)
        {
            this.Data = data;
        }

        public string Object { get; } = "list";

        public IEnumerable<T> Data { get; }
    }
}