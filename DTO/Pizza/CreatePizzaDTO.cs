using System;
using System.Collections.Generic;

namespace Javi.DTO
{
    public class CreatePizzaDTO
    {
        public string Name { get; set; }
        public ICollection<Guid> Ingredients { get; set; }

    }
}