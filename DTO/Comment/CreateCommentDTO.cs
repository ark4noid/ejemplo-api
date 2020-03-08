using System;

namespace Javi.DTO
{
    public class CreateCommentDTO
    {
        [Required]
        public User User { get; set; }
        [Required]
        public Pizza Pizza { get; set; }
        [Required]
        public string Text { get; set; }
    }
}