using System.ComponentModel.DataAnnotations;

namespace FiveMinusThree.Api.DTOs.ThemeDTO
{
    public class ThemeDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        //One-to-many realtionship
       
    }
}
