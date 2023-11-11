using System.ComponentModel.DataAnnotations;

namespace MyWebApplication.Models.DB
{
    public class VerUsers
    {
        [Key]
        public int user_id { get; set; }
        public string Fullname { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Birthdate { get; set; }
        public DateTime Created_at { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDateTime { get; set; }
    }
}
