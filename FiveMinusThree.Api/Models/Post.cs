using System.ComponentModel.DataAnnotations.Schema;

namespace FiveMinusThree.Api.Models
{
    public class Post
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string? Content { get; set; }
        public DateTime CreatedDate { get; set; }
        //One-to-many
        public virtual Theme Theme { get; set; }
        
        public Guid ThemeId { get; set; }
        
        public virtual User User { get; set; }
        
        public Guid? UserId { get; set; }
        public virtual List<Comment>? Comments { get; set; }
    }
}
