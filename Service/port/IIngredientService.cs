using CoffeMachine.Model.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoffeMachine.Service.port
{
    public interface IIngredientService
    {
        Task<List<IngredientDTO>> ListAll();

        Task<IngredientDTO> FindById(int ItemId);

        Task<IngredientDTO> Add(IngredientDTO ingredient);

        Task<IngredientDTO> UpdateById(int ItemId, IngredientDTO ingredient);

        Task<IngredientDTO> DeleteById(int ItemId);
    }
}
