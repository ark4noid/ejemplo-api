using System.Collections.Generic;
using System.Linq;
using Javi.Domain;
using Javi.DTO;
using Javi.Infraestructure;

namespace Javi.Application
{
    public class BusinessLogic
    {
        private readonly PizzeriaContext _context;
        public BusinessLogic(PizzeriaContext context)
        {
            this._context = context;
        }
        private ReadIngredientDTO _createReadIngredientDTO(Ingredient ingredient)
        {
            var dto = new ReadIngredientDTO();
            dto.Id = ingredient.Id;
            dto.Name = ingredient.Name;
            return dto;
        }
        public ICollection<ReadIngredientDTO> GetAllIngredients()
        {

            return _context.Ingredient.Select(ingredient => this._createReadIngredientDTO(ingredient)).ToList();


        }

    }
}