using System;
using System.ComponentModel.DataAnnotations;

namespace Javi.DTO
{
    public class CreateUserDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddressAttribute]
        public string Email { get; set; }
        [Required]
        [MinLength(8)]
        public string Password { get; set; }
    }
}