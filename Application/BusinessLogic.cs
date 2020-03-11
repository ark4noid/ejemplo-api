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
            var user = _createUser(dto);
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
           var comment = _createComment(dto, user);
            // añadir comentario a la pizza
            //guardar el comentario
            _context.Comment.Add(comment);
            // guardar y dispose del context
            _context.SaveChanges();
            _context.Dispose();
            // devolver readCommentDTO
            return _createReadCommentDTO(comment);
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

            // crear pizza
            var pizza = new Pizza();
            pizza.Id = Guid.NewGuid();
            pizza.Name = dto.Name;
            pizza.PizzaIngredients = new List<PizzaIngredient>();
            pizza.Comments = new List<Comment>();
            // add pizza ingredients
            foreach (var ingredientId in dto.Ingredients)
            {
                var ingredient = _context.Ingredient.Find(ingredientId);
                // createPizzaIngredient
                var pizzaIngredient = new PizzaIngredient();
                pizzaIngredient.Pizza = pizza;
                pizzaIngredient.Ingredient = ingredient;
                pizzaIngredient.PizzaId = pizza.Id;
                pizzaIngredient.IngredientId = ingredient.Id;
                //
                pizza.PizzaIngredients.Add(pizzaIngredient);
            }
            // var pizza = _cretePizza(dto);
            // _addPizzaIngredients(pizza, dto.Ingredients)
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
            var user = new User();
            user.Id = Guid.NewGuid();
            user.Name = dto.Name;
            user.Email = dto.Email;
            user.Password = dto.Password;
            return user;
        }
        private ReadUserDTO _createReadUserDTO(User user)
        {

        }
        private Comment _createComment(CreateCommentDTO dto, User user)
        {
           var comment =  new Comment();
            comment.Text = dto.Text;
            comment.User = user;
            return comment;
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