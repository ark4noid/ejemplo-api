using System;

namespace Javi.Domain
{
    public class PizzaIngredient
    {
        public Ingredient Ingredient { get; set; }
        public Guid IngredientId { get; set; }
        public Pizza Pizza { get; set; }
        public Guid PizzaId { get; set; }

    }

}