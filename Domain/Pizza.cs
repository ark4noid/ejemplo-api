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
            private double CosteFijo = 5.00;
            private double CosteAcumulado = 0.0;
            foreach (var ingrediente in PizzaIngredients){
                CosteAcumulado += ingrediente.Price;
            }
            return CosteAcumulado + CosteFijo;
        }
    }
}