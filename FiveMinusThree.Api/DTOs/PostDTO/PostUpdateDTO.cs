using System.ComponentModel.DataAnnotations;
namespace FiveMinusThree.Api.DTOs.PostDTO
{
    public class PostUpdateDTO
    {
        [Required]
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        
        
    }
}
