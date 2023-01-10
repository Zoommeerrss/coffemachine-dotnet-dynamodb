using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
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

        async Task ICoffeService.DeleteCoffeType(string type, string desc)
        {
            await this.dynamoBDContext.DeleteAsync<CoffeType>(type, desc, null);
        }

        async Task<CoffeTypeDTO> ICoffeService.GetCoffeType(string type, string desc)
        {
            var entity = await this.dynamoBDContext.LoadAsync<CoffeType>(type, desc);

            return CoffeTypeConverter.EntitytoDTO(entity);
        }

        async Task<CoffeTypeDTO> ICoffeService.PutCoffeType(string type, string desc, CoffeTypeDTO coffe)
        {
            var entity = await this.dynamoBDContext.LoadAsync<CoffeType>(type, desc);
                        
            await this.dynamoBDContext.SaveAsync<CoffeType>(CoffeTypeConverter.DTOtoEntity(coffe));

            return CoffeTypeConverter.EntitytoDTO(entity);
        }
    }
}
