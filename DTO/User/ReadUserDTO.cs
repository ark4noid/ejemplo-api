using System;
using Javi.Domain;

namespace Javi.DTO
{
    public class ReadUserDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}