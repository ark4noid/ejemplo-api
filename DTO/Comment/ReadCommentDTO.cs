using System;
using Javi.Domain;

namespace Javi.DTO
{
    public class ReadCommentDTO
    {
        public Guid Id { get; set; }
        public ReadUserDTO User { get; set; }
        public string Text { get; set; }
    }
}