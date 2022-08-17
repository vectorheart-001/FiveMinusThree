﻿using System.ComponentModel.DataAnnotations;
namespace FiveMinusThree.Api.DTOs.UserDTO
{
    public class UserLoginRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
        
    }
}
