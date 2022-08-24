using System.ComponentModel.DataAnnotations;

namespace FiveMinusThree.Api.DTOs.PostDTO
{
    public class PostCreateDTO
    {
       
        public string Title { get; set; }

        public string? Content { get; set; }
       
        public Guid ThemeId { get; set; }
        
    }
}
