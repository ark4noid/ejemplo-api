using System;
using System.Collections.Generic;

namespace Javi.Domain
{
    public class Pizza
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<PizzaIngredient> PizzaIngredients { get; set; }
        public double Price
        {
            get { return _calculatePrice(); }
        }
        private double _calculatePrice()
        {
            // TODO: implementarlo
            return 0.0;
        }
    }
}