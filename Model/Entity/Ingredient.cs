using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoffeMachine.Model.Entity
{
    public class Ingredient
    {
        // attributes

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ItemId { get; set; }
        public String Name { get; set; }
        public int Quantity { get; set; }
        public DateTime LastUpdate { get; set; }

        public string ToString()
        {
            return $"Ingredient: {ItemId}, {Name}, {Quantity}, {LastUpdate}";
        }
    }
}
