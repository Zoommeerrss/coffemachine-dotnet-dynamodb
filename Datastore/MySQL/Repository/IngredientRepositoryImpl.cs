using CoffeMachine.Datastore.MySQL.Repository.port;
using CoffeMachine.Model.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeMachine.Datastore.MySQL.Repository
{
    public class IngredientRepositoryImpl: IIngredientRepository
    {

        private readonly ILogger<IngredientRepositoryImpl> _logger;
        private readonly IngredientContext _context;

        public IngredientRepositoryImpl(ILogger<IngredientRepositoryImpl> logger, IngredientContext context)
        {
            _logger = logger;
            this._context = context;
        }

        public async Task Add(Ingredient ingredient)
        {
            await _context.Ingredient.AddAsync(ingredient);
            _context.SaveChanges();
        }

        public async Task<Ingredient> DeleteById(int ItemId)
        {
            var item = await _context.Ingredient.FirstOrDefaultAsync(ingredient => ingredient.ItemId == ItemId);

            if (item == null)
                throw new ArgumentNullException("Ingrediente not exists!");
            else
            {
                _context.Ingredient.Remove(item);
                _context.SaveChanges();
            }

            return item;
        }

        public async Task<List<Ingredient>> ListAll()
        {

            var list = await _context.Ingredient.Select(
                item => new Ingredient
                {
                    ItemId = item.ItemId,
                    Name = item.Name,
                    Quantity = item.Quantity,
                    LastUpdate = item.LastUpdate
                }
            ).ToListAsync();

            return list;
        }

        public async Task<Ingredient> FindById(int ItemId)
        {
            var item = await _context.Ingredient.FirstOrDefaultAsync(ingredient => ingredient.ItemId == ItemId);

            if (item == null)
                throw new ArgumentNullException("Ingrediente not exists!");
            
            return item;
        }

        public async Task<Ingredient> UpdateById(int ItemId, Ingredient ingredient)
        {
            var item = await _context.Ingredient.FirstOrDefaultAsync(ingredient => ingredient.ItemId == ItemId);

            if (item == null)
                throw new ArgumentNullException("Ingrediente not exists!");
            else
            {

                item.Name = ingredient.Name;
                item.Quantity = ingredient.Quantity;
                item.LastUpdate = ingredient.LastUpdate;

                _context.Ingredient.Update(item);
                _context.SaveChanges();
            }

            return ingredient;
        }

    }
}
