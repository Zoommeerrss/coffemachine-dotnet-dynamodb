using System;

namespace CoffeMachine.Model.Request
{
    public class IngredientRequest
    {
        public IngredientRequest() { }

        // attributes
        //public int ItemId { get; set; }
        public String Name { get; set; }
        public int Quantity { get; set; }
        public DateTime LastUpdate { get; set; }

        public string ToString()
        {
            return $"IngredientRequest:  {Name}, {Quantity}, {LastUpdate}";
        }
    }
}
