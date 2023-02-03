using CoffeMachine.Model.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoffeMachine.Datastore.MySQL.Repository.port
{
    public interface IIngredientRepository
    {
        Task<List<Ingredient>> ListAll();

        Task<Ingredient> FindById(int ItemId);

        Task Add(Ingredient ingredient);

        Task<Ingredient> UpdateById(int ItemId, Ingredient ingredient);

        Task<Ingredient> DeleteById(int ItemId);
    }
}
