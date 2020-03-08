using Javi.Domain;
using Microsoft.EntityFrameworkCore;

namespace Javi.Infraestructure
{
    public class PizzeriaContext : DbContext
    {
        public DbSet<Pizza> Pizza { get; set; }
        public DbSet<Ingredient> Ingredient { get; set; }
        public DbSet<PizzaIngredient> PizzaIngredient { get; set; }
        public Dbset<User> User { get; set; }
        public PizzeriaContext(DbContextOptions<PizzeriaContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ingredient>(ingredient =>
            {
                ingredient.HasKey(i => i.Id);
                ingredient.Property(i => i.Price).IsRequired();
                ingredient.Property(i => i.Name).IsRequired();
            });
            modelBuilder.Entity<Pizza>(pizza =>
            {
                pizza.HasKey(p => p.Id);
                pizza.Property(p => p.Name).IsRequired();
                pizza.Ignore(p => p.Price);
            });
            modelBuilder.Entity<PizzaIngredient>(pi =>
            {
                pi.HasKey(pi => new { pi.IngredientId, pi.PizzaId });
                pi
                    .HasOne<Pizza>(pi => pi.Pizza)
                    .WithMany(p => p.PizzaIngredients)
                    .HasForeignKey(pi => pi.PizzaId);
                pi
                    .HasOne<Ingredient>(pi => pi.Ingredient)
                    .WithMany()
                    .HasForeignKey(pi => pi.IngredientId);
            });
            modelBuilder.Entity<User>(user =>
            {
                user.HasKey(u => u.Id);
                user.Property(u => u.Name).IsRequired();
                user.Property(u => u.email).IsRequired();
                                
            });
            modelBuilder.Entity<Comment>(comment =>
            {
               comment.HasKey(c => c.Id);
               comment.Property(c => c.User).IsRequired();
               comment.Property(c => c.Text).IsRequired();
               comment.Property(c => c.Pizza).IsRequired();
            });
        }


    }

}

