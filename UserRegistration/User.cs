using System.ComponentModel.DataAnnotations;

namespace UserRegistration
{
    public class User
    {
        public User()
        {

        }

        [Key]
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public List<Hero> Heroes { get; set; }
    }
}

