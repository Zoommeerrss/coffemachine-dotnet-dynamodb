using System;

namespace CoffeMachine.Model.Response
{
    public class IngredientResponse
    {
        public IngredientResponse() { }
        public IngredientResponse(int itemId, string name, int quantity, DateTime lastUpdate)
        {
            ItemId = itemId;
            Name = name;
            Quantity = quantity;
            LastUpdate = lastUpdate;
        }

        // attributes
        public int ItemId { get; set; }
        public String Name { get; set; }
        public int Quantity { get; set; }
        public DateTime LastUpdate { get; set; }

        public string ToString()
        {
            return $"IngredientsResponse: {ItemId}, {Name}, {Quantity}, {LastUpdate}";
        }
    }
}
