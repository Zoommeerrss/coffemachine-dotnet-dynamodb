using CoffeMachine.Model.DTO;
using CoffeMachine.Model.Entity;
using CoffeMachine.Model.Request;
using CoffeMachine.Model.Response;
using System;
using System.Collections.Generic;

namespace CoffeMachine.Model.Converter
{
    public class CoffeTypeConverter
    {

        public static CoffeType DTOtoEntity(CoffeTypeDTO dto)
        {
            CoffeType c = new CoffeType();
            c.Type = dto.Type;
            c.Desc = dto.Desc;
            c.Coffe = dto.Coffe;
            c.Milk = dto.Milk;
            c.Water = dto.Water;
            c.Chocolate = dto.Chocolate;
            return c;
        }

        public static CoffeTypeResponse DTOtoResponse(CoffeTypeDTO dto)
        {
            CoffeTypeResponse c = new CoffeTypeResponse();
            c.Type = dto.Type;
            c.Desc = dto.Desc;
            c.Coffe = dto.Coffe;
            c.Milk = dto.Milk;
            c.Water = dto.Water;
            c.Chocolate = dto.Chocolate;
            return c;
        }

        public static CoffeTypeDTO EntitytoDTO(CoffeType entity)
        {
            CoffeTypeDTO c = new CoffeTypeDTO();
            c.Type = entity.Type;
            c.Desc = entity.Desc;
            c.Coffe = entity.Coffe;
            c.Milk = entity.Milk;
            c.Water = entity.Water;
            c.Chocolate = entity.Chocolate;
            return c;
        }

        public static CoffeTypeDTO RequesttoDTO(CoffeTypeRequest request)
        {
            CoffeTypeDTO c = new CoffeTypeDTO();
            c.Type = request.Type;
            c.Desc = request.Desc;
            c.Coffe = request.Coffe;
            c.Milk = request.Milk;
            c.Water = request.Water;
            c.Chocolate = request.Chocolate;
            return c;
        }
    }
}
