namespace CoffeMachine.Model.Response
{
    public class CoffeTypeResponse
    {
        public CoffeTypeResponse() { }

        public CoffeTypeResponse(string type, string desc, bool coffe, bool milk, bool water, bool chocolate)
        {
            Type = type;
            Desc = desc;
            Coffe = coffe;
            Milk = milk;
            Water = water;
            Chocolate = chocolate;
        }

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
            return $"CoffeTypeResponse: {Type}, {Desc}, {Coffe}, {Milk}, {Water}, {Chocolate}";
        }
    }
}
