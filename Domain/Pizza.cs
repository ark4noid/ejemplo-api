using System;
using System.Collections.Generic;

namespace Javi.Domain
{
    public class Pizza
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<PizzaIngredient> PizzaIngredients { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public double Price
        {
            get { return _calculatePrice(); }
        }
        private double _calculatePrice()
        {
            double CosteFijo = 5.00;
            double CosteAcumulado = 0.0;
            foreach (var pizzaIngredient in PizzaIngredients)
            {
                CosteAcumulado += pizzaIngredient.Ingredient.Price;
            }
            return CosteAcumulado + CosteFijo;
        }
    }
}