using System.ComponentModel.DataAnnotations;
namespace FiveMinusThree.Api.DTOs.UserDTO

{
    public class UserRegisterRequest
    {
        
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }
    }
}
