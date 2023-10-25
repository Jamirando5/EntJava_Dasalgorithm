using System.ComponentModel.DataAnnotations;

namespace MyWebApplication.Models.ViewModel
{
    public class VerUserModel
    {
        [Key]
        public int user_id { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Fullname")]
        public string Fullname { get; set; }


        [Required(ErrorMessage = "*")]
        [Display(Name = "Username")]
        public string Username { get; set; }


        [Required(ErrorMessage = "*")]
        [Display(Name = "Email")]
        public string Email { get; set; }


        [Required(ErrorMessage = "*")]
        [Display(Name = "Password")]
        public string Password { get; set; }


        [Required(ErrorMessage = "*")]
        [Display(Name = "Birthdate")]
        public string Birthdate { get; set; }
        public DateTime Created_at { get; set; }
    }
    public class VerUsersModel
    {
        public List<VerUserModel> VerUsers { get; set; }
    }

}
