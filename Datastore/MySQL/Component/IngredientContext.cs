using CoffeMachine.Model.Entity;
using Microsoft.EntityFrameworkCore;

namespace CoffeMachine.Datastore.MySQL
{
    public class IngredientContext : DbContext
    {
        public IngredientContext(DbContextOptions<IngredientContext> options) : base(options) { }

        public DbSet<Ingredient> Ingredient { get; set; }
         
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(IngredientContext).Assembly);

            modelBuilder.Entity<Ingredient>().ToTable("Ingredient");

            // Configure Primary Keys  
            modelBuilder.Entity<Ingredient>().HasKey(item => item.ItemId).HasName("ItemId");

            // Configure columns  
            modelBuilder.Entity<Ingredient>().Property(item => item.ItemId).HasColumnType("int").IsRequired();
            modelBuilder.Entity<Ingredient>().Property(item => item.Name).HasColumnType("nvarchar(30)").IsRequired();
            modelBuilder.Entity<Ingredient>().Property(item => item.Quantity).HasColumnType("int");
            modelBuilder.Entity<Ingredient>().Property(item => item.LastUpdate).HasColumnType("datetime");
        }
    }
}
