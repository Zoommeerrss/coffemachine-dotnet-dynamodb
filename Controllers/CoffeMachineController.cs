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
using CoffeMachine.Model.Request;
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
        public async Task<ApiResponse<CoffeTypeResponse>> GetCoffeType(string type, string desc)
        {
            try
            {
                var result = await this._coffeService.GetCoffeType(type, desc);

                return new ApiResponse<CoffeTypeResponse>(200, new CoffeTypeResponse(
                    result.Type, result.Desc, result.Coffe, result.Milk, result.Water, result.Chocolate
                ));
            }
            catch (Exception e)
            {
                Console.WriteLine("Error occurred: {0}", e.Message);

                return new ApiResponse<CoffeTypeResponse>(404);
            }

        }
        
        // PUT 
        [HttpPut("{type}/{desc}")]
        public async Task<ApiResponse<CoffeTypeResponse>> PutCoffeTypeAsync(string type, string desc, [FromBody] CoffeTypeRequest coffe)
        {
            try
            {

                await this._coffeService.PutCoffeType(type, desc, CoffeTypeConverter.RequesttoDTO(coffe));
                return new ApiResponse<CoffeTypeResponse>(200);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error occurred: {0}", e);

                return new ApiResponse<CoffeTypeResponse>(404);
            }
            
        }

        // POST 
        [HttpPost]
        public async Task<ApiResponse<CoffeTypeResponse>> AddCoffeType([FromBody] CoffeTypeRequest type) 
        {
            try
            {
                await this._coffeService.AddCoffeType(CoffeTypeConverter.RequesttoDTO(type));
                return new ApiResponse<CoffeTypeResponse>(200);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error occurred: {0}", e.Message);

                return new ApiResponse<CoffeTypeResponse>(404);
            }
        }

        // DELETE 
        [HttpDelete("{type}/{desc}")]
        public async Task<ApiResponse<CoffeTypeResponse>> DeleteCoffeTypeAsync(string type, string desc)
        {            
            try
            {
                await this._coffeService.DeleteCoffeType(type, desc);
                return new ApiResponse<CoffeTypeResponse>(200);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error occurred: {0}", e);

                return new ApiResponse<CoffeTypeResponse>(404);
            }
        }

    }
}
