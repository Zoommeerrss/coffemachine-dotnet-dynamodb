using Amazon.DynamoDBv2.DataModel;
using System;

namespace CoffeMachine.Model.Request
{
    public class CoffeTypeRequest
    {
        public CoffeTypeRequest() { }

        // partition key or hask key
        public string Type { get; set; }

        // sort key or range key
        public string Desc { get; set; }

        // attributes
        public bool Coffe { get; set; }
        public bool Milk { get; set; }
        public bool Water { get; set; }
        public bool Chocolate { get; set; }

        public string ToString()
        {
            return $"CoffeTypeRequest: {Type}, {Desc}, {Coffe}, {Milk}, {Water}, {Chocolate}";
        }
    }
}
