using System;
using System.Collections.Generic;
using System.Linq;
using Javi.Domain;
using Javi.DTO;
using Javi.Infraestructure;
using Microsoft.EntityFrameworkCore;

namespace Javi.Application
{
    public class BusinessLogic
    {
        private readonly PizzeriaContext _context;
        public BusinessLogic(PizzeriaContext context)
        {
            this._context = context;
        }
        public ReadUserDTO CreateUser(CreateUserDTO dto)
        {
            var user = new User();
            user.Id = Guid.NewGuid();
            user.Name = dto.Name;
            user.Email = dto.Email;
            user.Password = dto.Password;

            _context.User.Add(user);
            _context.SaveChanges();
            _context.Dispose();
            return _createReadUserDTO(user);
        }
        public ReadCommentDTO CreateComment(CreateCommentDTO dto)
        {
            // buscar el user
            var user = _context.User.Find(dto.UserId);
            // buscar la pizza
            var pizza = _context.Pizza.Find(dto.PizzaId);
            // crear comentario 
            // añadir comentario a la pizza
            // gaurdar el comentario
            // guardar y dispose del context
            // devolver readCommentDTO
        }
        public ReadPizzaDTO GetPizzaByID(Guid Id)
        {
            var pizza = _context.Pizza
            .Include(p => p.PizzaIngredients)
            .ThenInclude(pi => pi.Ingredient)
            .SingleOrDefault(p => p.Id == Id);
            return _createReadPizzaDTO(pizza);
        }
        public ICollection<PizzaSummaryDTO> GetAllPizzas()
        {
            return _context.Pizza.Select(pizza => this._createPizzaSummaryDTO(pizza)).ToList();
        }
        public ReadPizzaDTO CreatePizza(CreatePizzaDTO dto)
        {
            var pizza = new Pizza();
            pizza.Id = Guid.NewGuid();
            pizza.Name = dto.Name;
            pizza.PizzaIngredients = new List<PizzaIngredient>();
            foreach (var ingredientId in dto.Ingredients)
            {
                var ingredient = _context.Ingredient.Find(ingredientId);
                var pizzaIngredient = new PizzaIngredient();
                pizzaIngredient.Pizza = pizza;
                pizzaIngredient.Ingredient = ingredient;
                pizzaIngredient.PizzaId = pizza.Id;
                pizzaIngredient.IngredientId = ingredient.Id;
                pizza.PizzaIngredients.Add(pizzaIngredient);
            }
            _context.Pizza.Add(pizza);
            _context.SaveChanges();
            _context.Dispose();
            return _createReadPizzaDTO(pizza);
        }
        public ICollection<ReadIngredientDTO> GetAllIngredients()
        {

            return _context.Ingredient.Select(ingredient => this._createReadIngredientDTO(ingredient)).ToList();


        }
        private User _createUser(CreateUserDTO dto)
        {

        }
        private ReadUserDTO _createReadUserDTO(User user)
        {

        }
        private Comment _createComment(CreateCommentDTO dto)
        {

        }
        private ReadCommentDTO _createReadCommentDTO(Comment comment)
        {

        }
        private ReadPizzaDTO _createReadPizzaDTO(Pizza pizza)
        {
            var dto = new ReadPizzaDTO();
            dto.Id = pizza.Id;
            dto.Name = pizza.Name;
            dto.Ingredients = pizza.PizzaIngredients.Select(pi => _createReadIngredientDTO(pi.Ingredient)).ToList();
            return dto;
        }
        private PizzaSummaryDTO _createPizzaSummaryDTO(Pizza pizza)
        {
            var dto = new PizzaSummaryDTO();
            dto.Id = pizza.Id;
            dto.Name = pizza.Name;
            return dto;
        }
        private ReadIngredientDTO _createReadIngredientDTO(Ingredient ingredient)
        {
            var dto = new ReadIngredientDTO();
            dto.Id = ingredient.Id;
            dto.Name = ingredient.Name;
            return dto;
        }
    }
}