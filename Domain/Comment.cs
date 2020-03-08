using System;
using System.Collections.Generic;

namespace Javi.Domain
{
    public class Comment
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public User User {get; set; }
    }
}