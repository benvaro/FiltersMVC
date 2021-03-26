using System.ComponentModel.DataAnnotations;
using FiltersMVC.Attributes;

namespace FiltersMVC.Models
{
    public class UserViewModel
    {
        [NonEmptyRequired]
        [Display(Name = "User login")]
        public string Login { get; set; }
        
        public string Email { get; set; }
        [NonEmptyRequired]
        public string Password { get; set; }
    }
}