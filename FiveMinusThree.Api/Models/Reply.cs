namespace FiveMinusThree.Api.Models
{
    public class Reply
    {
        public Guid Id{ get; set; }
        public Post Post { get; set; }
        public Guid PostId{ get; set; }
        public virtual User User { get; set; }
        public Guid? UserId{ get; set; }
        public string Content { get; set; }
        public Guid? ReplyTo { get; set; }

    }
}
