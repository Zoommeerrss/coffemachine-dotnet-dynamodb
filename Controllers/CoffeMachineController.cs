using CoffeMachine.Model.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using CoffeMachine.Service.port;
using CoffeMachine.Model.Converter;
using CoffeMachine.Model.Response;
using System;

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

        [HttpGet("{type}/{desc}")]
        public async Task<ApiResponse<CoffeTypeResponse>> GetByTypeAndDesc(string type, string desc)
        {
            try
            {
                var result = await this._coffeService.GetByTypeAndDesc(type, desc);

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
        public async Task<ApiResponse<CoffeTypeResponse>> PutByTypeAndDesc(string type, string desc, [FromBody] CoffeTypeRequest coffe)
        {
            try
            {

                await this._coffeService.PutByTypeAndDesc(type, desc, CoffeTypeConverter.RequesttoDTO(coffe));
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
        public async Task<ApiResponse<CoffeTypeResponse>> Add([FromBody] CoffeTypeRequest type) 
        {
            try
            {
                await this._coffeService.Add(CoffeTypeConverter.RequesttoDTO(type));
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
                await this._coffeService.DeleteByTypeAndDesc(type, desc);
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
