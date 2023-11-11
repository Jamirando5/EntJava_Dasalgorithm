using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace MyWebApplication.Models.ViewModel
{
    public class VerUserModel
    {
        [Key]
        public int UserID { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Fullname")]
        public string Fullname { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [RegularExpression(@"^[\w\.-]+@[\w\.-]+\.\w+$", ErrorMessage = "Email should be a valid email address.")]
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
        public int RoleID { get; set; }  // Add this property
        public string RoleName { get; set; }
    }

    public class VerUsersModel
    {
        public List<VerUserModel> VerUsers { get; set; }
    }

    public class VerUserLoginModel
    {
        [Key]
        public int UserID { get; set; }

        [RegularExpression(@"^[\w\.-]+@[\w\.-]+\.\w+$", ErrorMessage = "Email should be a valid email address.")]
        [Required(ErrorMessage = "*")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}
