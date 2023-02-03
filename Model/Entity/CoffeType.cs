using Amazon.DynamoDBv2.DataModel;

namespace CoffeMachine.Model.Entity
{
    [DynamoDBTable("CoffeType")]
    public class CoffeType
    {

        // partition key or hask key
        [DynamoDBHashKey]
        public string Type { get; set; }

        // sort key or range key
        [DynamoDBRangeKey]
        public string Desc { get; set; }

        // attributes
        public bool Coffe { get; set; }
        public bool Milk { get; set; }
        public bool Water { get; set; }
        public bool Chocolate { get; set; }

        public string ToString()
        {
            return $"CoffeType: {Type}, {Desc}, {Coffe}, {Milk}, {Water}, {Chocolate}";
        }
           
    }
}
