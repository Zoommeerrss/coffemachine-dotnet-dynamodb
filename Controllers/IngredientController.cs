using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using CoffeMachine.Service.port;
using CoffeMachine.Model.Response;
using System;
using CoffeMachine.Model.DTO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using CoffeMachine.Model.Request;
using CoffeMachine.Model.Converter;

namespace CoffeMachine.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IngredientController : ControllerBase
    {

        private readonly ILogger<IngredientController> _logger;
        private readonly IIngredientService _ingredientService;

        public IngredientController(
            ILogger<IngredientController> logger,
            IIngredientService ingredientService)
        {
            _logger = logger;
            this._ingredientService = ingredientService;

        }

        [HttpGet]
        public async Task<ApiResponse<List<IngredientResponse>>> ListAll()
        {

            var dto = await this._ingredientService.ListAll();

            var result = dto.Select(item => new IngredientResponse
            {
                ItemId = item.ItemId,
                Name = item.Name,
                Quantity = item.Quantity,
                LastUpdate = item.LastUpdate
            }
             ).ToList();

            return new ApiResponse<List<IngredientResponse>>(200, result);

        }

        [HttpGet("{ItemId}")]
        public async Task<ApiResponse<IngredientResponse>> GetById(int ItemId)
        {
            try
            {
                var result = await this._ingredientService.FindById(ItemId);

                return new ApiResponse<IngredientResponse>(200, new IngredientResponse(
                    result.ItemId, result.Name, result.Quantity, result.LastUpdate
                ));
            }
            catch (Exception e)
            {
                Console.WriteLine("Error occurred: {0}", e.Message);

                return new ApiResponse<IngredientResponse>(404);
            }

        }

        // PUT 
        [HttpPut("{ItemId}")]
        public async Task<ApiResponse<IngredientResponse>> PutById(int ItemId, [FromBody] IngredientRequest ingredient)
        {

            var dto = await this._ingredientService.UpdateById(ItemId, IngredientConverter.RequesttoDTO(ingredient));
            return new ApiResponse<IngredientResponse>(200, IngredientConverter.DTOtoResponse(dto));
            
        }

        // POST 
        [HttpPost]
        public async Task<ApiResponse<IngredientResponse>> Add([FromBody] IngredientRequest ingredient)
        {
            try
            {
                await this._ingredientService.Add(IngredientConverter.RequesttoDTO(ingredient));
                return new ApiResponse<IngredientResponse>(200);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error occurred: {0}", e.Message);

                return new ApiResponse<IngredientResponse>(404);
            }
        }

        // DELETE 
        [HttpDelete("{ItemId}")]
        public async Task<ApiResponse<IngredientResponse>> DeleteById(int ItemId)
        {
            try
            {
                var dto = await this._ingredientService.DeleteById(ItemId);
                return new ApiResponse<IngredientResponse>(200, IngredientConverter.DTOtoResponse(dto));
            }
            catch (Exception e)
            {
                Console.WriteLine("Error occurred: {0}", e);

                return new ApiResponse<IngredientResponse>(404);
            }
        }
    }
}
