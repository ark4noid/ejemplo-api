using System;
using System.Collections.Generic;

namespace Javi.DTO
{
    public class ReadPizzaDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public ICollection<ReadIngredientDTO> Ingredients { get; set; }

    }

}