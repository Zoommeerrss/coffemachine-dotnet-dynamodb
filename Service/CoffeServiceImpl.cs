using Amazon.DynamoDBv2.DataModel;
using CoffeMachine.Model.Converter;
using CoffeMachine.Model.DTO;
using CoffeMachine.Model.Entity;
using CoffeMachine.Model.Request;
using CoffeMachine.Model.Response;
using CoffeMachine.Service.port;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeMachine.Service
{
    public class CoffeServiceImpl : ICoffeService
    {

        private readonly ILogger<CoffeServiceImpl> _logger;
        private readonly IDynamoDBContext dynamoBDContext;

        public CoffeServiceImpl(
            ILogger<CoffeServiceImpl> logger,
            IDynamoDBContext dynamoBDContext
        )
        {
            _logger = logger;
            this.dynamoBDContext = dynamoBDContext;
        }

        async Task ICoffeService.AddCoffeType(CoffeTypeDTO type)
        {
            await this.dynamoBDContext.SaveAsync<CoffeType>(CoffeTypeConverter.DTOtoEntity(type));            
        }

        async Task ICoffeService.DeleteCoffeType(int type)
        {
            await this.dynamoBDContext.DeleteAsync(type);
        }

        async Task<CoffeTypeDTO> ICoffeService.GetCoffeType(string type, string desc)
        {
            var entity = await this.dynamoBDContext.LoadAsync<CoffeType>(type, desc);

            _logger.LogInformation("CoffeTypeDTO: ", entity);

            CoffeTypeDTO c = new CoffeTypeDTO();
            c.Type = entity.Type;
            c.Desc = entity.Desc;
            c.Coffe = entity.Coffe;
            c.Milk = entity.Milk;
            c.Water = entity.Water;
            c.Chocolate = entity.Chocolate;
            return c;
        }

        async Task<CoffeTypeDTO> ICoffeService.PutCoffeType(int type, CoffeTypeDTO coffe)
        {
            /*CoffeType find = await this.dynamoBDContext.QueryAsync<CoffeType>(type).GetRemainingAsync();

            find.Type = coffe.Type;
            find.Desc = coffe.Desc;
            find.Coffe = coffe.Coffe;
            find.Milk = coffe.Milk;
            find.Water = coffe.Water;            
            find.Chocolate = coffe.Chocolate;

            await this.dynamoBDContext.SaveAsync<CoffeType>(find);*/

            //return CoffeTypeConverter.EntitytoDTO(find);
            return null;
        }
    }
}
