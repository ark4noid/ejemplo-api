using Javi.Domain;

namespace Javi.DTO
{
    public class ReadUserDTO
    {
        public static ReadUserDTO Create(User user)
        {
            var userRegistered = new ReadUserDTO()
            {
                Id = user.Id,
                Name= user.Name,
                Email = user.Email
            };
            return userRegistered;
        }
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
    }
}