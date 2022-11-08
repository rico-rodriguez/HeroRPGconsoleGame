using System.ComponentModel.DataAnnotations;

namespace UserRegistration
{
    public class UserController
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }




        public UserController(string username, string password, string confirmPassword)
        {
            Username = username;
            Password = password;
        }

        public UserController()
        {
        }
    }
}
