using System;

namespace CoffeMachine.Model.DTO
{
    public class IngredientDTO
    {
        public IngredientDTO() { }

        public IngredientDTO(int itemId, string name, int quantity, DateTime lastUpdate)
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
            return $"IngredientDTO: {ItemId}, {Name}, {Quantity}, {LastUpdate}";
        }
    }
}
