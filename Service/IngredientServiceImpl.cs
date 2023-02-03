using CoffeMachine.Datastore.MySQL.Repository.port;
using CoffeMachine.Model.Converter;
using CoffeMachine.Model.DTO;
using CoffeMachine.Model.Entity;
using CoffeMachine.Service.port;
using Microsoft.Extensions.Logging;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeMachine.Service
{
    public class IngredientServiceImpl : IIngredientService
    {

        private readonly ILogger<IngredientServiceImpl> _logger;
        private readonly IIngredientRepository _ingredientRepository;

        public IngredientServiceImpl(ILogger<IngredientServiceImpl> logger, IIngredientRepository ingredientRepository)
        {
            _logger = logger;
            _ingredientRepository = ingredientRepository;
        }

        public async Task<IngredientDTO> Add(IngredientDTO ingredient)
        {
            _ingredientRepository.Add(IngredientConverter.DTOtoEntity(ingredient));

            return null;
        }

        public async Task<IngredientDTO> DeleteById(int ItemId)
        {
            var entity = await _ingredientRepository.DeleteById(ItemId);

            return IngredientConverter.EntitytoDTO(entity);
        }

        public async Task<List<IngredientDTO>> ListAll()
        {
            var entity = await this._ingredientRepository.ListAll();
            
            var result = entity.Select(item => new IngredientDTO
                {
                    ItemId = item.ItemId,
                    Name = item.Name,
                    Quantity = item.Quantity,
                    LastUpdate = item.LastUpdate
                }
             ).ToList<IngredientDTO>();
            return result;
        }

        public async Task<IngredientDTO> FindById(int ItemId)
        {
            var entity = await _ingredientRepository.FindById(ItemId);

            return IngredientConverter.EntitytoDTO(entity);
        }

        public async Task<IngredientDTO> UpdateById(int ItemId, IngredientDTO ingredient)
        {
            var entity = await _ingredientRepository.UpdateById(ItemId, IngredientConverter.DTOtoEntity(ingredient));

            return IngredientConverter.EntitytoDTO(entity);
        }
    }
}