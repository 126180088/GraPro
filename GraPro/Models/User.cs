using System;
namespace GraPro.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
        public string Sex { get; set; }
        public string Birth { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public int Status { get; set; }
        public int RoleId { get; set; }
    }
}
