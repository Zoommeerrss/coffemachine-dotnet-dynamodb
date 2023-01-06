using CoffeMachine.Model.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.DynamoDBv2.DataModel;
using CoffeMachine.Service.port;
using CoffeMachine.Service;
using CoffeMachine.Model.Converter;
using CoffeMachine.Model.Response;
using System;
using System.Linq;

namespace CoffeMachine.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CoffeMachineController : ControllerBase
    {

        private readonly ILogger<CoffeMachineController> _logger;
        private readonly ICoffeService _coffeService;

        public CoffeMachineController(
            ILogger<CoffeMachineController> logger,
            ICoffeService coffeService)
        {
            _logger = logger;
            this._coffeService = coffeService;

        }

        [HttpGet]
        public ActionResult Welcome()
        {
            return new JsonResult("Welcome to the Coffe Machine!");
        }

        [HttpGet("{type}/{desc}")]
        public async Task<CoffeTypeResponse> GetCoffeType(string type, string desc)
        {
            var result = await this._coffeService.GetCoffeType(type, desc);
            return new CoffeTypeResponse(200, new JsonResult(result));
        }
        
        // PUT 
        [HttpPut("{type}")]
        public async Task<CoffeTypeResponse> PutCoffeTypeAsync(int type, [FromBody] CoffeTypeRequest coffe)
        {
            await this._coffeService.PutCoffeType(type, CoffeTypeConverter.RequesttoDTO(coffe));
            return new CoffeTypeResponse(200);
        }

        // POST 
        [HttpPost]
        public async Task<CoffeTypeResponse> AddCoffeType([FromBody] CoffeTypeRequest type) 
        {
            try
            {
                await this._coffeService.AddCoffeType(CoffeTypeConverter.RequesttoDTO(type));
                return new CoffeTypeResponse(200);
            }
            catch (Exception e)
            {
                return new CoffeTypeResponse(404);
            }
        }

        // DELETE 
        [HttpDelete("{type}")]
        public async Task<CoffeTypeResponse> DeleteCoffeTypeAsync(int type)
        {
            try
            {
                await this._coffeService.DeleteCoffeType(type);
                return new CoffeTypeResponse(200);
            }
            catch (Exception e)
            {
                return new CoffeTypeResponse(404);
            }
        }

    }
}
