using System;
using System.Collections.Generic;

namespace Javi.DTO
{
    public class CreatePizzaDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Guid> Ingredients { get; set; }

    }
}