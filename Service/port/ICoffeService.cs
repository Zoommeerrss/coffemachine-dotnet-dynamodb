using CoffeMachine.Model.DTO;
using CoffeMachine.Model.Request;
using CoffeMachine.Model.Response;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeMachine.Service.port
{
    public interface ICoffeService
    {
        public Task<CoffeTypeDTO> GetCoffeType(string type, string desc);

        public Task AddCoffeType(CoffeTypeDTO type);

        public Task<CoffeTypeDTO> PutCoffeType(string type, string desc, CoffeTypeDTO coffe);

        public Task DeleteCoffeType(string type, string desc);
    }
}
