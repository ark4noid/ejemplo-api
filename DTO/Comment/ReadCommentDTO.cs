namespace Javi.DTO
{
    public class ReadCommentDTO
    {
        public static ReadCommentDTO Create(Comment comment)
        {
            var commentRegistered = new ReadCommentDTO()
            {
                Id = comment.Id,
                User= comment.User,
                Text = comment.Text,
                Pizza = comment.Pizza
                
            };
            return commentRegistered;
        }
        public Guid Id { get; set; }
        public User User { get; set; }
        public string Text { get; set; }
        public Pizza Pizza  { get; set; }
    }
}