using System;
using System.ComponentModel.DataAnnotations;
using Javi.Domain;

namespace Javi.DTO
{
    public class CreateCommentDTO
    {
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public Guid PizzaId { get; set; }
        [Required]
        public string Text { get; set; }
    }
}