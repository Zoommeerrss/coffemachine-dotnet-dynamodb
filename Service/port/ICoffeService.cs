using CoffeMachine.Model.DTO;
using System.Threading.Tasks;

namespace CoffeMachine.Service.port
{
    public interface ICoffeService
    {
        public Task<CoffeTypeDTO> GetByTypeAndDesc(string type, string desc);

        public Task Add(CoffeTypeDTO type);

        public Task<CoffeTypeDTO> PutByTypeAndDesc(string type, string desc, CoffeTypeDTO coffe);

        public Task DeleteByTypeAndDesc(string type, string desc);
    }
}
