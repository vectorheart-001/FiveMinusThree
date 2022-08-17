using System.ComponentModel.DataAnnotations.Schema;
namespace FiveMinusThree.Api.Models
{
    public class Comment
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public virtual User User { get; set; }
        
        public Guid? UserId { get; set; }
        public virtual Post Post { get; set; }
        
        public Guid PostId { get; set; }

    }
}
