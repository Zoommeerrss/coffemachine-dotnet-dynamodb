using CoffeMachine.Model.DTO;
using CoffeMachine.Model.Entity;
using CoffeMachine.Model.Request;
using CoffeMachine.Model.Response;

namespace CoffeMachine.Model.Converter
{
    public class IngredientConverter
    {
        public static Ingredient DTOtoEntity(IngredientDTO dto)
        {
            Ingredient c = new Ingredient();
            c.ItemId = dto.ItemId;
            c.Name = dto.Name;
            c.Quantity = dto.Quantity;
            c.LastUpdate = dto.LastUpdate;
            return c;
        }

        public static IngredientResponse DTOtoResponse(IngredientDTO dto)
        {
            IngredientResponse c = new IngredientResponse();
            c.ItemId = dto.ItemId;
            c.Name = dto.Name;
            c.Quantity = dto.Quantity;
            c.LastUpdate = dto.LastUpdate;
            return c;
        }

        public static IngredientDTO EntitytoDTO(Ingredient entity)
        {
            IngredientDTO c = new IngredientDTO();
            c.ItemId = entity.ItemId;
            c.Name = entity.Name;
            c.Quantity = entity.Quantity;
            c.LastUpdate = entity.LastUpdate;
            return c;
        }

        public static IngredientDTO RequesttoDTO(IngredientRequest request)
        {
            IngredientDTO c = new IngredientDTO();
            //c.ItemId = request.ItemId;
            c.Name = request.Name;
            c.Quantity = request.Quantity;
            c.LastUpdate = request.LastUpdate;
            return c;
        }
    }
}
