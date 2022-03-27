using System;
namespace GraPro.Models
{
    public class User
    {
        public int Id { get; set; }
        
        public string UserName { get; set; }

        public string Account { get; set; }
        public string Password { get; set; }
        public string Telephone { get; set; }

        public string Email { get; set; }

        public string Status { get; set; }

        public string Role { get; set; }

        public DateTime StartTime { get; set; }
    }
}
