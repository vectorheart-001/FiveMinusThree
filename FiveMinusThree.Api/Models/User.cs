using System.ComponentModel.DataAnnotations;
namespace FiveMinusThree.Api.Models
{
    public class User
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }
        
        public string Email { get; set; }
        public string Password { get; set; }
        public virtual List<Post> Posts { get; set; }
        public virtual List<Comment> Comments { get; set; }
       
        
    }
    
}
