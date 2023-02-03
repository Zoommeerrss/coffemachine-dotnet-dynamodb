using Amazon.DynamoDBv2.DataModel;
using CoffeMachine.Model.Converter;
using CoffeMachine.Model.DTO;
using CoffeMachine.Model.Entity;
using CoffeMachine.Service.port;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeMachine.Service
{
    public class CoffeServiceImpl : ICoffeService
    {

        private readonly ILogger<CoffeServiceImpl> _logger;
        private readonly IDynamoDBContext dynamoBDContext;

        private readonly IIngredientService _ingredientService;

        public CoffeServiceImpl(
            ILogger<CoffeServiceImpl> logger,
            IDynamoDBContext dynamoBDContext,
            IIngredientService ingredientService
        )
        {
            _logger = logger;
            this.dynamoBDContext = dynamoBDContext;
            _ingredientService = ingredientService; ;
        }

        async Task ICoffeService.Add(CoffeTypeDTO type)
        {
            await this.dynamoBDContext.SaveAsync<CoffeType>(CoffeTypeConverter.DTOtoEntity(type));            
        }

        async Task ICoffeService.DeleteByTypeAndDesc(string type, string desc)
        {
            await this.dynamoBDContext.DeleteAsync<CoffeType>(type, desc, null);
        }

        async Task<CoffeTypeDTO> ICoffeService.GetByTypeAndDesc(string type, string desc)
        {
            Console.WriteLine("CoffeServiceImpl.GetCoffeType init");

            var entity = await this.dynamoBDContext.LoadAsync<CoffeType>(type, desc);
            return CoffeTypeConverter.EntitytoDTO(entity);
        }

        async Task<CoffeTypeDTO> ICoffeService.PutByTypeAndDesc(string type, string desc, CoffeTypeDTO coffe)
        {
            var entity = await this.dynamoBDContext.LoadAsync<CoffeType>(type, desc);
                        
            await this.dynamoBDContext.SaveAsync<CoffeType>(CoffeTypeConverter.DTOtoEntity(coffe));

            return CoffeTypeConverter.EntitytoDTO(entity);
        }
    }
}
